using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuickRentProject.Models;
using QuickRentProjectDb.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace QuickRentProject.Controllers
{
    public class BookingsController : Controller
    {
        private readonly QuickRentProjectDbContext _context;

        public BookingsController(QuickRentProjectDbContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            // Track the current filter and sort selection for the view
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = string.IsNullOrEmpty(sortOrder) ? "start_asc" : sortOrder;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            IQueryable<Booking> booking = _context.Booking
                .Include(b => b.Item)
                .Include(b => b.Renter);

            // Renter: see only their own bookings (Admin sees all)
            if (User.IsInRole("Renter") && !User.IsInRole("Admin"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                booking = booking.Where(b => b.RenterId == userId);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                booking = booking.Where(b =>
                    b.ItemId.ToString().Contains(searchString)
                );
            }

            switch (ViewData["CurrentSort"] as string)
            {
                case "start_desc":
                    booking = booking.OrderByDescending(b => b.StartDate); break;
                case "end_asc":
                    booking = booking.OrderBy(b => b.EndDate); break;
                case "end_desc":
                    booking = booking.OrderByDescending(b => b.EndDate); break;
                case "cost_asc":
                    booking = booking.OrderBy(b => b.TotalCost); break;
                case "cost_desc":
                    booking = booking.OrderByDescending(b => b.TotalCost); break;
        
                case "item_asc":
                    booking = booking.OrderBy(b => b.Item.Name); break; // item name
                case "item_desc":
                    booking = booking.OrderByDescending(b => b.Item.Name); break;
                case "renter_asc":
                    booking = booking.OrderBy(b => b.Renter.LastName).ThenBy(b => b.Renter.FirstName); break;
                case "renter_desc":
                    booking = booking.OrderByDescending(b => b.Renter.LastName).ThenByDescending(b => b.Renter.FirstName); break;
                case "start_asc":
                default:
                    booking = booking.OrderBy(b => b.StartDate); break;
            }

            int pageSize = 10;
            return View(await PaginatedList<Booking>.CreateAsync(booking.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Bookings/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var booking = await _context.Booking
                .Include(b => b.Item)
                .Include(b => b.Renter)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null) return NotFound();

            // Renter: can view only own booking
            if (User.IsInRole("Renter") && !User.IsInRole("Admin"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (booking.RenterId != userId) return Forbid();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        [HttpGet]
        [Authorize(Roles = "Admin,Renter")]
        public async Task<IActionResult> Create(int? itemId = null)
        {
            // Only available items; preselect when coming from Rent button
            var itemsQuery = _context.Item.AsNoTracking().Where(i => i.IsAvailable);
            ViewData["ItemId"] = new SelectList(await itemsQuery.ToListAsync(), "ItemId", "Name", itemId);

            if (User.IsInRole("Renter") && !User.IsInRole("Admin"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);
                ViewData["RenterFullName"] = user != null ? $"{user.FirstName} {user.LastName}" : userId;
                ViewData["RenterId"] = userId; // will be posted via hidden input
            }
            else
            {
                // Admin: dropdown only for users in Renter role
                var renterRoleId = await _context.Roles
                    .Where(r => r.Name == "Renter")
                    .Select(r => r.Id)
                    .FirstOrDefaultAsync();

                var renters = await _context.Users.AsNoTracking()
                    .Where(u => _context.UserRoles.Any(ur => ur.UserId == u.Id && ur.RoleId == renterRoleId))
                    .OrderBy(u => u.LastName).ThenBy(u => u.FirstName)
                    .Select(u => new { u.Id, Name = u.FirstName + " " + u.LastName + " (" + u.Email + ")" })
                    .ToListAsync();

                ViewData["RenterId"] = new SelectList(renters, "Id", "Name");
            }

            return View();
        }

        // POST: Bookings/Create
        [HttpPost]
        [Authorize(Roles = "Admin,Renter")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,StartDate,EndDate,TotalCost,RenterId,ItemId")] Booking booking)
        {
            if (User.IsInRole("Renter") && !User.IsInRole("Admin"))
            {
                booking.RenterId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            var now = DateTime.Now;
            var start = booking.StartDate;
            var end = booking.EndDate;

            if (start < now) ModelState.AddModelError(nameof(Booking.StartDate), "Start must be now or later.");
            if (start > now.AddDays(14)) ModelState.AddModelError(nameof(Booking.StartDate), "Start must be within the next 14 days.");
            if (end <= start) ModelState.AddModelError(nameof(Booking.EndDate), "End must be after the start.");
            if (end > start.AddMonths(12)) ModelState.AddModelError(nameof(Booking.EndDate), "Booking cannot exceed 12 months.");

            if (!ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();

                // After creating booking, go to Payments/Create with this booking selected
                return RedirectToAction("Create", "Payments", new { bookingId = booking.BookingId });
            }

            // rebuild lists on validation failure (redisplay)
            var itemsQuery = _context.Item.AsNoTracking().Where(i => i.IsAvailable);
            ViewData["ItemId"] = new SelectList(await itemsQuery.ToListAsync(), "ItemId", "Name", booking.ItemId);

            if (User.IsInRole("Renter") && !User.IsInRole("Admin"))
            {
                var userId = booking.RenterId;
                var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);
                ViewData["RenterFullName"] = user != null ? $"{user.FirstName} {user.LastName}" : userId;
                ViewData["RenterId"] = userId;
            }
            else
            {
                var renterRoleId = await _context.Roles
                    .Where(r => r.Name == "Renter")
                    .Select(r => r.Id)
                    .FirstOrDefaultAsync();

                var renters = await _context.Users.AsNoTracking()
                    .Where(u => _context.UserRoles.Any(ur => ur.UserId == u.Id && ur.RoleId == renterRoleId))
                    .OrderBy(u => u.LastName).ThenBy(u => u.FirstName)
                    .Select(u => new { u.Id, Name = u.FirstName + " " + u.LastName + " (" + u.Email + ")" })
                    .ToListAsync();

                ViewData["RenterId"] = new SelectList(renters, "Id", "Name", booking.RenterId);
            }

            return View(booking);
        }

        // GET: Bookings/Edit/5
        [Authorize(Roles = "Admin,Renter")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var booking = await _context.Booking.FindAsync(id);
            if (booking == null) return NotFound();

            // Renter: can edit only own booking
            if (User.IsInRole("Renter") && !User.IsInRole("Admin"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (booking.RenterId != userId) return Forbid();

                // Show renter full name (read-only)
                var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);
                ViewData["RenterFullName"] = user != null ? $"{user.FirstName} {user.LastName}" : userId;
                ViewData["RenterId"] = userId;
            }
            else
            {
                // Admin: dropdown with renters only
                var renterRoleId = await _context.Roles
                    .Where(r => r.Name == "Renter")
                    .Select(r => r.Id)
                    .FirstOrDefaultAsync();

                var renters = await _context.Users.AsNoTracking()
                    .Where(u => _context.UserRoles.Any(ur => ur.UserId == u.Id && ur.RoleId == renterRoleId))
                    .OrderBy(u => u.LastName).ThenBy(u => u.FirstName)
                    .Select(u => new { u.Id, Name = u.FirstName + " " + u.LastName + " (" + u.Email + ")" })
                    .ToListAsync();

                ViewData["RenterList"] = new SelectList(renters, "Id", "Name", booking.RenterId);
            }

            // Item dropdown shows names
            ViewData["ItemId"] = new SelectList(_context.Item, "ItemId", "Name", booking.ItemId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin,Renter")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingId,StartDate,EndDate,TotalCost,RenterId,ItemId")] Booking booking)
        {
            if (id != booking.BookingId) return NotFound();

            if (User.IsInRole("Renter") && !User.IsInRole("Admin"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var dbBooking = await _context.Booking.AsNoTracking().FirstOrDefaultAsync(b => b.BookingId == id);
                if (dbBooking == null || dbBooking.RenterId != userId) return Forbid();
                booking.RenterId = userId;
            }

            var now = DateTime.Now;
            var start = booking.StartDate;
            var end = booking.EndDate;

            if (start < now)
                ModelState.AddModelError(nameof(Booking.StartDate), "Start must be now or later.");
            if (start > now.AddDays(14))
                ModelState.AddModelError(nameof(Booking.StartDate), "Start must be within the next 14 days.");
            if (end <= start)
                ModelState.AddModelError(nameof(Booking.EndDate), "End must be after the start.");
            if (end > start.AddMonths(12))
                ModelState.AddModelError(nameof(Booking.EndDate), "Booking cannot exceed 12 months.");

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Booking.Any(e => e.BookingId == booking.BookingId)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["ItemId"] = new SelectList(_context.Item, "ItemId", "Name", booking.ItemId);
            if (User.IsInRole("Renter") && !User.IsInRole("Admin"))
            {
                var userId = booking.RenterId;
                var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);
                ViewData["RenterFullName"] = user != null ? $"{user.FirstName} {user.LastName}" : userId;
                ViewData["RenterId"] = userId;
            }
            else
            {
                var renterRoleId = await _context.Roles
                    .Where(r => r.Name == "Renter")
                    .Select(r => r.Id)
                    .FirstOrDefaultAsync();

                var renters = await _context.Users.AsNoTracking()
                    .Where(u => _context.UserRoles.Any(ur => ur.UserId == u.Id && ur.RoleId == renterRoleId))
                    .OrderBy(u => u.LastName).ThenBy(u => u.FirstName)
                    .Select(u => new { u.Id, Name = u.FirstName + " " + u.LastName + " (" + u.Email + ")" })
                    .ToListAsync();

                ViewData["RenterList"] = new SelectList(renters, "Id", "Name", booking.RenterId);
            }
            return View(booking);
        }

        // GET: Bookings/Delete/5
        [Authorize(Roles = "Admin,Renter")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var booking = await _context.Booking
                .Include(b => b.Item)
                .Include(b => b.Renter)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null) return NotFound();

            // Renter: can delete only own booking
            if (User.IsInRole("Renter") && !User.IsInRole("Admin"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (booking.RenterId != userId) return Forbid();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin,Renter")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Booking.FindAsync(id);
            if (booking != null)
            {
                // Renter: ensure ownership
                if (User.IsInRole("Renter") && !User.IsInRole("Admin"))
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (booking.RenterId != userId) return Forbid();
                }

                _context.Booking.Remove(booking);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
