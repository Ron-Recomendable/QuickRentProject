using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using QuickRentProject.Models;

namespace QuickRentProject.Areas.Identity.Data;

// Add profile data for application users by adding properties to the QuickRentProjectUser class
public class QuickRentProjectUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Role { get; set; }
    public ICollection<Item> Items { get; set; } // Items owned by the user
    public ICollection<Booking> Bookings { get; set; } // Bookings made by the user
    public ICollection<Review> Reviews { get; set; } // Reviews written by the user
}

