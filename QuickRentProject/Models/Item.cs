using QuickRentProject.Areas.Identity.Data;

namespace QuickRentProject.Models
{
    public class Item
    {
        public int ItemId { get; set; } // Primary key
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal PricePerDay { get; set; }
        public bool IsAvailable { get; set; } = true;
        public string Location { get; set; }

        // Foreign key to ApplicationUser (Owner)
        public string OwnerId { get; set; }
        public QuickRentProjectUser Owner { get; set; } // Navigation property

        // Navigation properties
        public ICollection<Booking> Bookings { get; set; } // Bookings for this item
        public ICollection<Review> Reviews { get; set; } // Reviews for this item
    }
}
