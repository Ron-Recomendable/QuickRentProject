using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuickRentProject.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; } // Primary key

        [Required(ErrorMessage = "Please enter the amount")]
        [Column(TypeName = "decimal(10, 2)")]
        [Range(0.01, 100000.00, ErrorMessage = "Amount must be between 0.01 and 100,000.00")]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; } // Amount paid

        [Required(ErrorMessage = "Please enter the payment date")]
        [Display(Name = "Payment Date")]
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow; // Date of payment

        [Required(ErrorMessage = "Please select a payment method")]
        [MaxLength(50, ErrorMessage = "Payment method cannot exceed 50 characters")]
        [Display(Name = "Payment Method")]
        public string PaymentMethod { get; set; } // Payment method (e.g., Credit Card, PayPal)

        // Foreign key to Booking
        [Required]
        public int BookingId { get; set; } // Booking associated with the payment

        [ForeignKey("BookingId")]
        public Booking Booking { get; set; } // Navigation property for booking
    }
}
