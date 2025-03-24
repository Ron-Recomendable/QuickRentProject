using QuickRentProject.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuickRentProject.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; } // Primary key

        [Required(ErrorMessage = "Please enter a rating")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        [Display(Name = "Rating")]
        public int Rating { get; set; } // Rating (1 to 5)

        [MaxLength(500, ErrorMessage = "Comment cannot exceed 500 characters")]
        [Display(Name = "Comment")]
        public string Comment { get; set; } // Review comment

        [Required(ErrorMessage = "Please enter the review date")]
        [Display(Name = "Review Date")]
        public DateTime ReviewDate { get; set; } = DateTime.UtcNow; // Date of the review

        // Foreign key to Item
        [Required]
        public int ItemId { get; set; } // Item being reviewed

        [ForeignKey("ItemId")]
        public Item Item { get; set; } // Navigation property for item

        // Foreign key to QuickRentProjectUser (User who wrote the review)
        [Required]
        public string UserId { get; set; } // User who wrote the review

        [ForeignKey("UserId")]
        public QuickRentProjectUser User { get; set; } // Navigation property for user
    }
}
