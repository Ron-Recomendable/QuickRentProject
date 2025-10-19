using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuickRentProject.Models;
using QuickRentProjectDb.Data;

namespace QuickRentProject.Controllers
{
    [Authorize] // must be signed-in
    public class PaymentsController : Controller
    {
        private readonly QuickRentProjectDbContext _context;

        public PaymentsController(QuickRentProjectDbContext context)
        {
            _context = context;
        }

        // GET: Payments
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = string.IsNullOrEmpty(sortOrder) ? "date_asc" : sortOrder;

            var payments = _context.Payment
                .Include(p => p.Booking)
                    .ThenInclude(b => b.Renter)
                .Include(p => p.Booking)
                    .ThenInclude(b => b.Item)
                .AsQueryable();

            // Renters only see their own payments
            if (User.IsInRole("Renter") && !User.IsInRole("Admin"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                payments = payments.Where(p => p.Booking.RenterId == userId);
            }

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                payments = payments.Where(p =>
                    p.Amount.ToString().Contains(searchString) ||
                    p.PaymentMethod.Contains(searchString) ||
                    (p.Booking.Item != null && p.Booking.Item.Name.Contains(searchString)) ||
                    (p.Booking.Renter != null && (
                        p.Booking.Renter.FirstName.Contains(searchString) ||
                        p.Booking.Renter.LastName.Contains(searchString))));
            }

            switch (ViewData["CurrentSort"] as string)
            {
                case "amount_asc":
                    payments = payments.OrderBy(p => p.Amount);
                    break;
                case "amount_desc":
                    payments = payments.OrderByDescending(p => p.Amount);
                    break;
                case "date_asc":
                    payments = payments.OrderBy(p => p.PaymentDate);
                    break;
                case "date_desc":
                    payments = payments.OrderByDescending(p => p.PaymentDate);
                    break;
                case "method_asc":
                    payments = payments.OrderBy(p => p.PaymentMethod);
                    break;
                case "method_desc":
                    payments = payments.OrderByDescending(p => p.PaymentMethod);
                    break;
                case "booking_asc":
                    payments = payments
                        .OrderBy(p => p.Booking.Renter.FirstName)
                        .ThenBy(p => p.Booking.Renter.LastName);
                    break;
                case "booking_desc":
                    payments = payments
                        .OrderByDescending(p => p.Booking.Renter.FirstName)
                        .ThenByDescending(p => p.Booking.Renter.LastName);
                    break;
                default:
                    payments = payments.OrderBy(p => p.PaymentDate);
                    break;
            }

            return View(await payments.AsNoTracking().ToListAsync());
        }

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payment
                .Include(p => p.Booking)
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Payments/Create
        [Authorize(Roles = "Admin,Renter")]
        public async Task<IActionResult> Create()
        {
            // Restrict booking selection
            if (User.IsInRole("Renter") && !User.IsInRole("Admin"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var myBookings = await _context.Booking
                    .Include(b => b.Item)
                    .Where(b => b.RenterId == userId)
                    .Select(b => new
                    {
                        b.BookingId,
                        Label = b.Item != null
                            ? $"{b.Item.Name} ({b.StartDate:yyyy-MM-dd} → {b.EndDate:yyyy-MM-dd})"
                            : $"Booking #{b.BookingId}"
                    })
                    .ToListAsync();

                ViewData["BookingId"] = new SelectList(myBookings, "BookingId", "Label");
            }
            else
            {
                var allBookings = await _context.Booking
                    .Include(b => b.Item)
                    .Include(b => b.Renter)
                    .Select(b => new
                    {
                        b.BookingId,
                        Label = $"{b.Renter.FirstName} {b.Renter.LastName} - {(b.Item != null ? b.Item.Name : "Item")} ({b.StartDate:yyyy-MM-dd} → {b.EndDate:yyyy-MM-dd})"
                    })
                    .ToListAsync();

                ViewData["BookingId"] = new SelectList(allBookings, "BookingId", "Label");
            }

            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin,Renter")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentId,Amount,PaymentDate,PaymentMethod,BookingId")] Payment payment)
        {
            // Ownership check on selected booking
            if (User.IsInRole("Renter") && !User.IsInRole("Admin"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var booking = await _context.Booking.AsNoTracking().FirstOrDefaultAsync(b => b.BookingId == payment.BookingId);
                if (booking == null || booking.RenterId != userId) return Forbid();
            }

            if (ModelState.IsValid)
            {
                _context.Add(payment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Rebuild booking list if validation failed
            await Create();
            return View(payment);
        }

        // GET: Payments/Edit/5
        [Authorize(Roles = "Admin,Renter")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var payment = await _context.Payment
                .Include(p => p.Booking)
                .ThenInclude(b => b.Item)
                .FirstOrDefaultAsync(p => p.PaymentId == id);
            if (payment == null) return NotFound();

            // Ownership guard
            if (User.IsInRole("Renter") && !User.IsInRole("Admin"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var booking = await _context.Booking.AsNoTracking().FirstOrDefaultAsync(b => b.BookingId == payment.BookingId);
                if (booking == null || booking.RenterId != userId) return Forbid();

                // Restrict selectable bookings to current renter
                var myBookings = await _context.Booking
                    .Include(b => b.Item)
                    .Where(b => b.RenterId == userId)
                    .Select(b => new
                    {
                        b.BookingId,
                        Label = b.Item != null
                            ? $"{b.Item.Name} ({b.StartDate:yyyy-MM-dd} → {b.EndDate:yyyy-MM-dd})"
                            : $"Booking #{b.BookingId}"
                    })
                    .ToListAsync();

                ViewData["BookingId"] = new SelectList(myBookings, "BookingId", "Label", payment.BookingId);
            }
            else
            {
                var allBookings = await _context.Booking
                    .Include(b => b.Item)
                    .Include(b => b.Renter)
                    .Select(b => new
                    {
                        b.BookingId,
                        Label = $"{b.Renter.FirstName} {b.Renter.LastName} - {(b.Item != null ? b.Item.Name : "Item")} ({b.StartDate:yyyy-MM-dd} → {b.EndDate:yyyy-MM-dd})"
                    })
                    .ToListAsync();

                ViewData["BookingId"] = new SelectList(allBookings, "BookingId", "Label", payment.BookingId);
            }

            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin,Renter")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentId,Amount,PaymentDate,PaymentMethod,BookingId")] Payment payment)
        {
            if (id != payment.PaymentId) return NotFound();

            // Ownership guard for both existing payment and new BookingId
            if (User.IsInRole("Renter") && !User.IsInRole("Admin"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var existing = await _context.Payment
                    .Include(p => p.Booking)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.PaymentId == id);
                if (existing == null || existing.Booking.RenterId != userId) return Forbid();

                var targetBooking = await _context.Booking.AsNoTracking().FirstOrDefaultAsync(b => b.BookingId == payment.BookingId);
                if (targetBooking == null || targetBooking.RenterId != userId) return Forbid();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payment);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _context.Payment.AnyAsync(e => e.PaymentId == id)) return NotFound();
                    throw;
                }
            }

            // Rebuild lists if validation fails
            return await Edit(id);
        }

        // GET: Payments/Delete/5
        [Authorize(Roles = "Admin,Renter")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var payment = await _context.Payment
                .Include(p => p.Booking)
                    .ThenInclude(b => b.Renter)
                .Include(p => p.Booking)
                    .ThenInclude(b => b.Item)
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (payment == null) return NotFound();

            if (User.IsInRole("Renter") && !User.IsInRole("Admin"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (payment.Booking.RenterId != userId) return Forbid();
            }

            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin,Renter")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payment = await _context.Payment
                .Include(p => p.Booking)
                .FirstOrDefaultAsync(p => p.PaymentId == id);
            if (payment != null)
            {
                if (User.IsInRole("Renter") && !User.IsInRole("Admin"))
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (payment.Booking.RenterId != userId) return Forbid();
                }

                _context.Payment.Remove(payment);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
