using QuickRentProject.Areas.Identity.Data;

namespace QuickRentProject.Models
{
    public class Booking
    {
        public int BookingId { get; set; } // Primary key
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalCost { get; set; }
        public string Status { get; set; } // e.g., Pending, Confirmed, Completed, Cancelled

        // Foreign key to ApplicationUser (Renter)
        public string RenterId { get; set; }
        public QuickRentProjectUser Renter { get; set; } // Navigation property

        // Foreign key to Item
        public int ItemId { get; set; }
        public Item Item { get; set; } // Navigation property

        // Navigation property
        public ICollection<Payment> Payments { get; set; } // Payments for this booking
    }
}
