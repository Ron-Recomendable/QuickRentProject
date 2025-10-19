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

namespace QuickRentProject.Controllers
{
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

            IQueryable<Payment> payments = _context.Payment
                .Include(p => p.Booking)
                .ThenInclude(b => b.Renter); // make renter name available

            if (!string.IsNullOrEmpty(searchString))
            {
                payments = payments.Where(p =>
                    p.Amount.ToString().Contains(searchString) ||
                    p.PaymentId.ToString().Contains(searchString) ||
                    (p.PaymentMethod != null && p.PaymentMethod.Contains(searchString)) ||
                    (p.Booking != null && (
                        p.Booking.RenterId.Contains(searchString) ||
                        (p.Booking.Renter != null && (
                            p.Booking.Renter.FirstName.Contains(searchString) ||
                            p.Booking.Renter.LastName.Contains(searchString)
                        ))
                    )));
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
        public IActionResult Create()
        {
            ViewData["BookingId"] = new SelectList(_context.Booking, "BookingId", "RenterId");
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
            if (!ModelState.IsValid)
            {
                _context.Add(payment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookingId"] = new SelectList(_context.Booking, "BookingId", "RenterId", payment.BookingId);
            return View(payment);
        }

        // GET: Payments/Edit/5
        [Authorize(Roles = "Admin,Renter")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payment.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            ViewData["BookingId"] = new SelectList(_context.Booking, "BookingId", "RenterId", payment.BookingId);
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
            if (id != payment.PaymentId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(payment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentExists(payment.PaymentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookingId"] = new SelectList(_context.Booking, "BookingId", "RenterId", payment.BookingId);
            return View(payment);
        }

        // GET: Payments/Delete/5
        [Authorize(Roles = "Admin,Renter")]
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin,Renter")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payment = await _context.Payment.FindAsync(id);
            if (payment != null)
            {
                _context.Payment.Remove(payment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentExists(int id)
        {
            return _context.Payment.Any(e => e.PaymentId == id);
        }
    }
}
