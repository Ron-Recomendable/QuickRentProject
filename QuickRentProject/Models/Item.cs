using QuickRentProject.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuickRentProject.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; } // Primary key

        [Required(ErrorMessage = "Please enter the item name")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        [Display(Name = "Item Name")]
        public string Name { get; set; } // Name of the item

        [Required(ErrorMessage = "Please enter the description")]
        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        [Display(Name = "Description")]
        public string Description { get; set; } // Description of the item

        [Required(ErrorMessage = "Please select a category")]
        [MaxLength(50, ErrorMessage = "Category cannot exceed 50 characters")]
        [Display(Name = "Category")]
        public string Category { get; set; } // Category of the item (e.g., Car, Apartment)

        [Required(ErrorMessage = "Please enter the price")]
        [Column(TypeName = "decimal(10, 2)")]
        [Range(0.01, 10000.00, ErrorMessage = "Price must be between 0.01 and 10,000.00")]
        [Display(Name = "Price")]
        public decimal Price { get; set; } // Price of the item

        [Required]
        [Display(Name = "Is Available")]
        public bool IsAvailable { get; set; } = true; // Whether the item is available for rent

        [Required(ErrorMessage = "Please enter the location")]
        [MaxLength(100, ErrorMessage = "Location cannot exceed 100 characters")]
        [Display(Name = "Location")]
        // Require "City, <NZ Region>" with a valid NZ region (case-insensitive).
        // Allows letters, spaces, dot, apostrophe, hyphen in the City.
        [RegularExpression(
            @"^[\p{L}][\p{L}\s\.'-]{1,49},\s*(?i)(Northland|Auckland|Waikato|Bay of Plenty|Gisborne|Hawke's Bay|Taranaki|Manawatu-Whanganui|Manawatū-Whanganui|Wellington|Tasman|Nelson|Marlborough|West Coast|Canterbury|Otago|Southland)$",
            ErrorMessage = "Enter as 'City, Region' with a valid New Zealand region. Example: 'Auckland, Auckland' or 'Wellington, Wellington'.")]
        public string Location { get; set; }

        [Required]
        public string OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public QuickRentProjectUser Owner { get; set; }

        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
