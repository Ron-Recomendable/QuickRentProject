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
    [Authorize(Roles = "Admin,Renter")]
    public class ReviewsController : Controller
    {
        private readonly QuickRentProjectDbContext _context;

        public ReviewsController(QuickRentProjectDbContext context)
        {
            _context = context;
        }

        // GET: Reviews
        [AllowAnonymous]
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = string.IsNullOrEmpty(sortOrder) ? "rating_asc" : sortOrder;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            IQueryable<Review> reviews = _context.Review
                .Include(r => r.Item)
                .Include(r => r.User);

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                reviews = reviews.Where(r =>
                    r.Rating.ToString().Contains(searchString) ||
                    (r.Comment != null && r.Comment.Contains(searchString)) ||
                    (r.Item != null && r.Item.Name.Contains(searchString)) ||
                    (r.User != null && (
                        r.User.FirstName.Contains(searchString) ||
                        r.User.LastName.Contains(searchString))));
            }

            switch (ViewData["CurrentSort"] as string)
            {
                case "rating_asc":   reviews = reviews.OrderBy(r => r.Rating); break;
                case "rating_desc":  reviews = reviews.OrderByDescending(r => r.Rating); break;
                case "date_asc":     reviews = reviews.OrderBy(r => r.ReviewDate); break;
                case "date_desc":    reviews = reviews.OrderByDescending(r => r.ReviewDate); break;
                case "item_asc":     reviews = reviews.OrderBy(r => r.Item.Name); break;
                case "item_desc":    reviews = reviews.OrderByDescending(r => r.Item.Name); break;
                case "user_asc":     reviews = reviews.OrderBy(r => r.User.LastName).ThenBy(r => r.User.FirstName); break;
                case "user_desc":    reviews = reviews.OrderByDescending(r => r.User.LastName).ThenByDescending(r => r.User.FirstName); break;
                default:             reviews = reviews.OrderBy(r => r.Rating); break;
            }

            int pageSize = 10;
            return View(await PaginatedList<Review>.CreateAsync(reviews.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Reviews/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var review = await _context.Review
                .Include(r => r.Item)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.ReviewId == id);
            if (review == null) return NotFound();

            return View(review);
        }

        // GET: Reviews/Create
        public async Task<IActionResult> Create()
        {
            ViewData["ItemId"] = new SelectList(await _context.Item.OrderBy(i => i.Name).ToListAsync(), "ItemId", "Name");
            await PopulateCurrentUserNameAsync();
            ViewBag.Today = DateTime.Now.ToString("yyyy-MM-dd");
            return View();
        }

        // POST: Reviews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReviewId,Rating,Comment,ItemId")] Review review)
        {
            // Force server-side values
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            review.UserId = userId;
            review.ReviewDate = DateTime.Now;

            if (!ModelState.IsValid)
            {
                _context.Add(review);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ItemId"] = new SelectList(await _context.Item.OrderBy(i => i.Name).ToListAsync(), "ItemId", "Name", review.ItemId);
            await PopulateCurrentUserNameAsync();
            ViewBag.Today = DateTime.Now.ToString("yyyy-MM-dd");
            return View(review);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var review = await _context.Review
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.ReviewId == id);
            if (review == null) return NotFound();

            // Renter can edit only own review
            if (User.IsInRole("Renter") && !User.IsInRole("Admin"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (review.UserId != userId) return Forbid();
            }

            ViewData["ItemId"] = new SelectList(await _context.Item.OrderBy(i => i.Name).ToListAsync(), "ItemId", "Name", review.ItemId);
            ViewBag.ReviewDateText = review.ReviewDate.ToString("yyyy-MM-dd");
            ViewBag.CurrentUserName = review.User != null ? $"{review.User.FirstName} {review.User.LastName}" : "";
            return View(review);
        }

        // POST: Reviews/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReviewId,Rating,Comment,ItemId")] Review review)
        {
            if (id != review.ReviewId) return NotFound();

            // Load existing to enforce immutable fields and ownership
            var existing = await _context.Review.AsNoTracking().FirstOrDefaultAsync(r => r.ReviewId == id);
            if (existing == null) return NotFound();

            if (User.IsInRole("Renter") && !User.IsInRole("Admin"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (existing.UserId != userId) return Forbid();
            }

            // Preserve server-managed fields
            review.UserId = existing.UserId;
            review.ReviewDate = existing.ReviewDate;

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(review);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.ReviewId)) return NotFound();
                    throw;
                }
            }

            ViewData["ItemId"] = new SelectList(await _context.Item.OrderBy(i => i.Name).ToListAsync(), "ItemId", "Name", review.ItemId);
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == review.UserId);
            ViewBag.CurrentUserName = user != null ? $"{user.FirstName} {user.LastName}" : "";
            ViewBag.ReviewDateText = review.ReviewDate.ToString("yyyy-MM-dd");
            return View(review);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var review = await _context.Review
                .Include(r => r.Item)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.ReviewId == id);
            if (review == null) return NotFound();

            if (User.IsInRole("Renter") && !User.IsInRole("Admin"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (review.UserId != userId) return Forbid();
            }

            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var review = await _context.Review.FirstOrDefaultAsync(r => r.ReviewId == id);
            if (review != null)
            {
                if (User.IsInRole("Renter") && !User.IsInRole("Admin"))
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (review.UserId != userId) return Forbid();
                }

                _context.Review.Remove(review);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewExists(int id) => _context.Review.Any(e => e.ReviewId == id);

        private async Task PopulateCurrentUserNameAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            ViewBag.CurrentUserName = user != null ? $"{user.FirstName} {user.LastName}" : "";
        }
    }
}
