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
    [Authorize]
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
                .Include(p => p.Booking).ThenInclude(b => b.Renter)
                .Include(p => p.Booking).ThenInclude(b => b.Item)
                .AsQueryable();

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
                case "amount_asc": payments = payments.OrderBy(p => p.Amount); break;
                case "amount_desc": payments = payments.OrderByDescending(p => p.Amount); break;
                case "date_asc": payments = payments.OrderBy(p => p.PaymentDate); break;
                case "date_desc": payments = payments.OrderByDescending(p => p.PaymentDate); break;
                case "method_asc": payments = payments.OrderBy(p => p.PaymentMethod); break;
                case "method_desc": payments = payments.OrderByDescending(p => p.PaymentMethod); break;
                case "booking_asc": payments = payments.OrderBy(p => p.Booking.Renter.LastName).ThenBy(p => p.Booking.Renter.FirstName); break;
                case "booking_desc": payments = payments.OrderByDescending(p => p.Booking.Renter.LastName).ThenByDescending(p => p.Booking.Renter.FirstName); break;
                default: payments = payments.OrderBy(p => p.PaymentDate); break;
            }

            return View(await payments.AsNoTracking().ToListAsync());
        }

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var payment = await _context.Payment
                .Include(p => p.Booking).ThenInclude(b => b.Renter)
                .Include(p => p.Booking).ThenInclude(b => b.Item)
                .FirstOrDefaultAsync(m => m.PaymentId == id);

            if (payment == null) return NotFound();

            if (User.IsInRole("Renter") && !User.IsInRole("Admin"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (payment.Booking.RenterId != userId) return Forbid();
            }

            return View(payment);
        }

        // GET: Payments/Create
        [HttpGet]
        [Authorize(Roles = "Admin,Renter")]
        public async Task<IActionResult> Create(int? bookingId = null)
        {
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

                ViewData["BookingId"] = new SelectList(myBookings, "BookingId", "Label", bookingId);
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

                ViewData["BookingId"] = new SelectList(allBookings, "BookingId", "Label", bookingId);
            }

            // Prefill amount from booking, but do NOT lock it
            Payment model = new Payment { PaymentDate = DateTime.Now };
            if (bookingId.HasValue)
            {
                var booking = await _context.Booking.AsNoTracking()
                    .FirstOrDefaultAsync(b => b.BookingId == bookingId.Value);
                if (booking != null)
                {
                    if (User.IsInRole("Renter") && !User.IsInRole("Admin"))
                    {
                        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                        if (booking.RenterId != userId) return Forbid();
                    }

                    model.BookingId = booking.BookingId;
                    model.Amount = booking.TotalCost;

                    // Set client min/max for date: StartDate .. EndDate + 7 days
                    ViewBag.PaymentMinDate = booking.StartDate.Date.ToString("yyyy-MM-dd");
                    ViewBag.PaymentMaxDate = booking.EndDate.Date.AddDays(7).ToString("yyyy-MM-dd");
                }
            }

            return View(model);
        }

        // POST: Payments/Create
        [HttpPost]
        [Authorize(Roles = "Admin,Renter")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentId,Amount,PaymentDate,PaymentMethod,BookingId")] Payment payment)
        {
            // Validate renter owns the booking
            if (User.IsInRole("Renter") && !User.IsInRole("Admin"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var booking = await _context.Booking.AsNoTracking()
                    .FirstOrDefaultAsync(b => b.BookingId == payment.BookingId);
                if (booking == null || booking.RenterId != userId) return Forbid();
            }

            // Get booking for date validation (no longer overriding amount)
            var sourceBooking = await _context.Booking.AsNoTracking()
                .FirstOrDefaultAsync(b => b.BookingId == payment.BookingId);
            if (sourceBooking == null) return NotFound();

            // Server-side date window: StartDate .. EndDate + 7 days
            var minDate = sourceBooking.StartDate.Date;
            var maxDate = sourceBooking.EndDate.Date.AddDays(7);
            if (payment.PaymentDate.Date < minDate || payment.PaymentDate.Date > maxDate)
            {
                ModelState.AddModelError(nameof(payment.PaymentDate),
                    $"Payment date must be between {minDate:yyyy-MM-dd} and {maxDate:yyyy-MM-dd}.");
            }

            if (!ModelState.IsValid)
            {
                _context.Add(payment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // rebuild dropdown and client min/max on validation failure
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

            ViewBag.PaymentMinDate = minDate.ToString("yyyy-MM-dd");
            ViewBag.PaymentMaxDate = maxDate.ToString("yyyy-MM-dd");

            return View(payment);
        }

        // GET: Payments/Edit/5
        [HttpGet]
        [Authorize(Roles = "Admin,Renter")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var payment = await _context.Payment
                .Include(p => p.Booking)
                .ThenInclude(b => b.Item)
                .FirstOrDefaultAsync(p => p.PaymentId == id);
            if (payment == null) return NotFound();

            if (User.IsInRole("Renter") && !User.IsInRole("Admin"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var booking = await _context.Booking.AsNoTracking().FirstOrDefaultAsync(b => b.BookingId == payment.BookingId);
                if (booking == null || booking.RenterId != userId) return Forbid();

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

            // Client min/max for date: StartDate .. EndDate + 7 days
            if (payment.Booking != null)
            {
                ViewBag.PaymentMinDate = payment.Booking.StartDate.Date.ToString("yyyy-MM-dd");
                ViewBag.PaymentMaxDate = payment.Booking.EndDate.Date.AddDays(7).ToString("yyyy-MM-dd");
            }

            return View(payment);
        }

        // POST: Payments/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin,Renter")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentId,Amount,PaymentDate,PaymentMethod,BookingId")] Payment payment)
        {
            if (id != payment.PaymentId) return NotFound();

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

            // Validate date window against selected booking (amount is user-controlled)
            var bookingForPayment = await _context.Booking.AsNoTracking()
                .FirstOrDefaultAsync(b => b.BookingId == payment.BookingId);
            if (bookingForPayment == null) return NotFound();

            var minDate = bookingForPayment.StartDate.Date;
            var maxDate = bookingForPayment.EndDate.Date.AddDays(7);
            if (payment.PaymentDate.Date < minDate || payment.PaymentDate.Date > maxDate)
            {
                ModelState.AddModelError(nameof(payment.PaymentDate),
                    $"Payment date must be between {minDate:yyyy-MM-dd} and {maxDate:yyyy-MM-dd}.");
            }

            if (!ModelState.IsValid)
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

            // Rebuild dropdown and client min/max for redisplay
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

            ViewBag.PaymentMinDate = minDate.ToString("yyyy-MM-dd");
            ViewBag.PaymentMaxDate = maxDate.ToString("yyyy-MM-dd");

            return View(payment);
        }

        // GET: Payments/Delete/5
        [HttpGet]
        [Authorize(Roles = "Admin,Renter")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var payment = await _context.Payment
                .Include(p => p.Booking).ThenInclude(b => b.Renter)
                .Include(p => p.Booking).ThenInclude(b => b.Item)
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
