using QuickRentProject.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuickRentProject.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; } // Primary key

        [Required(ErrorMessage = "Please enter the start date")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; } // Start date of the booking

        [Required(ErrorMessage = "Please enter the end date")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; } // End date of the booking

        [Required(ErrorMessage = "Please enter the total cost")]
        [Column(TypeName = "decimal(10, 2)")]
        [Range(0.01, 100000.00, ErrorMessage = "Total cost must be between 0.01 and 100,000.00")]
        [Display(Name = "Total Cost")]
        public decimal TotalCost { get; set; } // Total cost of the booking

        [Required(ErrorMessage = "Please select a status")]
        [MaxLength(20, ErrorMessage = "Status cannot exceed 20 characters")]
        [Display(Name = "Status")]
        public string Status { get; set; } // Status of the booking (e.g., Pending, Confirmed)

        // Foreign key to QuickRentProjectUser (Renter)
        [Required]
        public string RenterId { get; set; } // Renter who made the booking

        [ForeignKey("RenterId")]
        public QuickRentProjectUser Renter { get; set; } // Navigation property for renter

        // Foreign key to Item
        [Required]
        public int ItemId { get; set; } // Item being booked

        [ForeignKey("ItemId")]
        public Item Item { get; set; } // Navigation property for item

        // Navigation property
        public ICollection<Payment> Payments { get; set; } // One-to-many relationship with Payment
    }
}
