namespace QuickRentProject.Models
{
    public class Payment
    {
        public int PaymentId { get; set; } // Primary key
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public string PaymentMethod { get; set; } // e.g., Credit Card, PayPal

        // Foreign key to Booking
        public int BookingId { get; set; }
        public Booking Booking { get; set; } // Navigation property
    }
}
