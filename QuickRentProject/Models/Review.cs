using QuickRentProject.Areas.Identity.Data;

namespace QuickRentProject.Models
{
    public class Review
    {
        public int ReviewId { get; set; } // Primary key
        public int Rating { get; set; } // Rating (1 to 5)
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; } = DateTime.UtcNow;

        // Foreign key to Item
        public int ItemId { get; set; }
        public Item Item { get; set; } // Navigation property

        // Foreign key to ApplicationUser (User who wrote the review)
        public string UserId { get; set; }
        public QuickRentProjectUser User { get; set; } // Navigation property
    }
}
