using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuickRentProject.Models;
using QuickRentProjectDb.Data;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QuickRentProject.Controllers
{
    [Authorize] // Require authentication for all actions
    public class ItemsController : Controller
    {
        private readonly QuickRentProjectDbContext _context;

        public ItemsController(QuickRentProjectDbContext context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["Category"] = sortOrder == "Category" ? "category_desc" : "Category";
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = string.IsNullOrEmpty(sortOrder) ? "name_asc" : sortOrder;

            IQueryable<Item> itemQuery = _context.Item.Include(i => i.Owner);

            // Owners see only their items, Admin sees all
            if (User.IsInRole("Owner") && !User.IsInRole("Admin"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                itemQuery = itemQuery.Where(i => i.OwnerId == userId);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                itemQuery = itemQuery.Where(s => s.Name.Contains(searchString)
                                       || s.Category.Contains(searchString));
            }

            switch (ViewData["CurrentSort"] as string)
            {
                case "name_asc":
                    itemQuery = itemQuery.OrderBy(s => s.Name);
                    break;
                case "name_desc":
                    itemQuery = itemQuery.OrderByDescending(s => s.Name);
                    break;
                case "category_asc":
                    itemQuery = itemQuery.OrderBy(s => s.Category);
                    break;
                case "category_desc":
                    itemQuery = itemQuery.OrderByDescending(s => s.Category);
                    break;
                case "price_asc":
                    itemQuery = itemQuery.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    itemQuery = itemQuery.OrderByDescending(s => s.Price);
                    break;
                default:
                    itemQuery = itemQuery.OrderBy(s => s.Name);
                    break;
            }
            return View(await itemQuery.AsNoTracking().ToListAsync());
        }

        // GET: Items/Create
        [Authorize(Roles = "Owner,Admin")]
        public async Task<IActionResult> Create()
        {
            var categories = new[]
            {
                "Electronics","Clothing","Groceries","Furniture","Appliances","Stationery",
                "Toys & Games","Sports & Outdoor","Beauty & Health","Books & Media",
                "Tools & Hardware","Home & Living","Automotive","Pet Supplies"
            };
            ViewData["CategoryList"] = new SelectList(categories);

            // Fix owner to the current user (show name, post hidden OwnerId)
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);
            var ownerFullName = user != null ? $"{user.FirstName} {user.LastName}" : userId;

            ViewData["OwnerFullName"] = ownerFullName;
            ViewData["OwnerId"] = userId;

            return View();
        }

        // POST: Items/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Owner,Admin")]
        public async Task<IActionResult> Create([Bind("ItemId,Name,Description,Category,Price,IsAvailable,Location,OwnerId")] Item item)
        {
            // Always set OwnerId to the current user
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            item.OwnerId = userId;

            if (!ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var categories = new[]
            {
                "Electronics","Clothing","Groceries","Furniture","Appliances","Stationery",
                "Toys & Games","Sports & Outdoor","Beauty & Health","Books & Media",
                "Tools & Hardware","Home & Living","Automotive","Pet Supplies"
            };
            ViewData["CategoryList"] = new SelectList(categories, item.Category);

            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);
            ViewData["OwnerFullName"] = user != null ? $"{user.FirstName} {user.LastName}" : userId;
            ViewData["OwnerId"] = userId;

            return View(item);
        }

        // GET: Items/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var item = await _context.Item
                .Include(i => i.Owner)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null) return NotFound();

            // Owners can only view their own items, Admin can view all
            if (User.IsInRole("Owner") && !User.IsInRole("Admin"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (item.OwnerId != userId) return Forbid();
            }

            return View(item);
        }

        // GET: Items/Edit/5
        [Authorize(Roles = "Owner,Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var item = await _context.Item.AsNoTracking().FirstOrDefaultAsync(i => i.ItemId == id);
            if (item == null) return NotFound();

            // Owners can only edit their own items, Admin can edit all
            if (User.IsInRole("Owner") && !User.IsInRole("Admin"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (item.OwnerId != userId) return Forbid();
            }

            // Category dropdown (preselect current)
            var categories = new[]
            {
                "Electronics","Clothing","Groceries","Furniture","Appliances","Stationery",
                "Toys & Games","Sports & Outdoor","Beauty & Health","Books & Media",
                "Tools & Hardware","Home & Living","Automotive","Pet Supplies"
            };
            ViewData["CategoryList"] = new SelectList(categories, item.Category);

            // Owner full name (read-only in view)
            var owner = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == item.OwnerId);
            ViewData["OwnerFullName"] = owner != null ? $"{owner.FirstName} {owner.LastName}" : item.OwnerId;

            return View(item);
        }

        // POST: Items/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Owner,Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,Name,Description,Category,Price,IsAvailable,Location,OwnerId")] Item item)
        {
            if (id != item.ItemId) return NotFound();

            // Owners can only edit their own items, Admin can edit all
            if (User.IsInRole("Owner") && !User.IsInRole("Admin"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var dbItem = await _context.Item.AsNoTracking().FirstOrDefaultAsync(i => i.ItemId == id);
                if (dbItem == null || dbItem.OwnerId != userId) return Forbid();
                item.OwnerId = userId; // Prevent changing ownership
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ItemId)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }

            // Rebuild dropdowns on validation errors
            var categories = new[]
            {
                "Electronics","Clothing","Groceries","Furniture","Appliances","Stationery",
                "Toys & Games","Sports & Outdoor","Beauty & Health","Books & Media",
                "Tools & Hardware","Home & Living","Automotive","Pet Supplies"
            };
            ViewData["CategoryList"] = new SelectList(categories, item.Category);

            var owner = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == item.OwnerId);
            ViewData["OwnerFullName"] = owner != null ? $"{owner.FirstName} {owner.LastName}" : item.OwnerId;

            return View(item);
        }

        // GET: Items/Delete/5
        [Authorize(Roles = "Owner,Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var item = await _context.Item
                .Include(i => i.Owner)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null) return NotFound();

            // Owners can only delete their own items, Admin can delete all
            if (User.IsInRole("Owner") && !User.IsInRole("Admin"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (item.OwnerId != userId) return Forbid();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Owner,Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Item.FindAsync(id);
            if (item == null) return NotFound();

            if (User.IsInRole("Owner") && !User.IsInRole("Admin"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (item.OwnerId != userId) return Forbid();
            }

            _context.Item.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Item.Any(e => e.ItemId == id);
        }
    }
}
