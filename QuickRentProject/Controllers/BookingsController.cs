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
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            // Track the current filter and sort selection for the view
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = string.IsNullOrEmpty(sortOrder) ? "start_asc" : sortOrder;

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
                    b.ItemId.ToString().Contains(searchString) ||
                    (b.Status != null && b.Status.Contains(searchString)));
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
                case "status_asc":
                    booking = booking.OrderBy(b => b.Status); break;
                case "status_desc":
                    booking = booking.OrderByDescending(b => b.Status); break;
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

            return View(await booking.AsNoTracking().ToListAsync());
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
        [Authorize(Roles = "Admin,Renter")]
        public IActionResult Create()
        {
            ViewData["ItemId"] = new SelectList(_context.Item, "ItemId", "Name");
            ViewData["RenterId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Bookings/Create
        [HttpPost]
        [Authorize(Roles = "Admin,Renter")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,StartDate,EndDate,TotalCost,Status,RenterId,ItemId")] Booking booking)
        {
            // Force renter to create only for themselves
            if (User.IsInRole("Renter") && !User.IsInRole("Admin"))
            {
                booking.RenterId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            if (!ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ItemId"] = new SelectList(_context.Item, "ItemId", "Name", booking.ItemId);
            ViewData["RenterId"] = new SelectList(_context.Users, "Id", "Id", booking.RenterId);
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
            }

            ViewData["ItemId"] = new SelectList(_context.Item, "ItemId", "Name", booking.ItemId);
            ViewData["RenterId"] = new SelectList(_context.Users, "Id", "Id", booking.RenterId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin,Renter")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingId,StartDate,EndDate,TotalCost,Status,RenterId,ItemId")] Booking booking)
        {
            if (id != booking.BookingId) return NotFound();

            // Renter: ensure ownership and prevent changing RenterId
            if (User.IsInRole("Renter") && !User.IsInRole("Admin"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var dbBooking = await _context.Booking.AsNoTracking().FirstOrDefaultAsync(b => b.BookingId == id);
                if (dbBooking == null || dbBooking.RenterId != userId) return Forbid();
                booking.RenterId = userId;
            }

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
            ViewData["RenterId"] = new SelectList(_context.Users, "Id", "Id", booking.RenterId);
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
