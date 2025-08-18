using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using QuickRentProject.Models;

namespace QuickRentProject.Areas.Identity.Data;

// Add profile data for application users by adding properties to the QuickRentProjectUser class
public class QuickRentProjectUser : IdentityUser
{
    [Required(ErrorMessage = "Please enter your first name")]
    [MaxLength(100, ErrorMessage = "First name cannot exceed 100 characters")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; } // User's first name

    [Required(ErrorMessage = "Please enter your last name")]
    [MaxLength(100, ErrorMessage = "Last name cannot exceed 100 characters")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; } // User's last name

    [Phone(ErrorMessage = "Please enter a valid phone number")]
    [Required(ErrorMessage = "Please enter your phone number")]
    [MaxLength(15, ErrorMessage = "Phone number cannot exceed 15 characters")]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; } // User's phone number

    [Required(ErrorMessage = "Please select a role")]
    [MaxLength(50, ErrorMessage = "Role cannot exceed 50 characters")]
    [Display(Name = "Role")]
    public string Role { get; set; } // User's role (e.g., Renter, Owner)
    public byte[]? ProfilePicture { get; set; }

    // Navigation properties
    public ICollection<Item> Items { get; set; } // One-to-many relationship with Item (for Owners)
    public ICollection<Booking> Bookings { get; set; } // One-to-many relationship with Booking (for Renters)
    public ICollection<Review> Reviews { get; set; } // One-to-many relationship with Review (for Renters)
}

