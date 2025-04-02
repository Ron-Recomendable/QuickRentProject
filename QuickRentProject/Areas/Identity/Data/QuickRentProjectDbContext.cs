using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuickRentProject.Areas.Identity.Data;
using QuickRentProject.Models;

namespace QuickRentProjectDb.Data;

public class QuickRentProjectDbContext : IdentityDbContext<QuickRentProjectUser>
{
    public QuickRentProjectDbContext(DbContextOptions<QuickRentProjectDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        var hasher = new PasswordHasher<QuickRentProjectUser>();

        // Seed Users
        builder.Entity<QuickRentProjectUser>().HasData(
            new QuickRentProjectUser
            {
                Id = "1",
                UserName = "Phoebe@example.com",
                NormalizedUserName = "PHOEBE@EXAMPLE.COM",
                Email = "pheobe@example.com",
                NormalizedEmail = "PHEOBE@EXAMPLE.COM",
                EmailConfirmed = true,
                FirstName = "Pheobe",
                LastName = "Townsend",
                PhoneNumber = "531531413",
                Role = "Admin",
                PasswordHash = hasher.HashPassword(null, "Pheobe123_"),
            },
            new QuickRentProjectUser
            {
                Id = "2",
                UserName = "Rivka@example.com",
                NormalizedUserName = "RIVKA@EXAMPLE.COM",
                Email = "Rivka@example.com",
                NormalizedEmail = "RIVKA@EXAMPLE.COM",
                EmailConfirmed = true,
                FirstName = "Rivka",
                LastName = "Simmons",
                PhoneNumber = "4211614135",
                Role = "Admin",
                PasswordHash = hasher.HashPassword(null, "Rivka123_"),
            },
            new QuickRentProjectUser
            {
                Id = "3",
                UserName = "Alianna@example.com",
                NormalizedUserName = "ALIANNA@EXAMPLE.COM",
                Email = "Alianna@example.com",
                NormalizedEmail = "ALIANNA@EXAMPLE.COM",
                EmailConfirmed = true,
                FirstName = "Alianna",
                LastName = "Murray",
                PhoneNumber = "7415135315",
                Role = "Renter",
                PasswordHash = hasher.HashPassword(null, "Alianna123_"),
            },
            new QuickRentProjectUser
            {
                Id = "4",
                UserName = "Carolyn@example.com",
                NormalizedUserName = "CAROLYN@EXAMPLE.COM",
                Email = "Carolyn@example.com",
                NormalizedEmail = "CAROLYN@EXAMPLE.COM",
                EmailConfirmed = true,
                FirstName = "Carolyn",
                LastName = "Reese",
                PhoneNumber = "631641431",
                Role = "Renter",
                PasswordHash = hasher.HashPassword(null, "Carolyn123_"),
            }
        );
    }

public DbSet<QuickRentProject.Models.Item> Item { get; set; } = default!;

public DbSet<QuickRentProject.Models.Booking> Booking { get; set; } = default!;

public DbSet<QuickRentProject.Models.Payment> Payment { get; set; } = default!;

public DbSet<QuickRentProject.Models.Review> Review { get; set; } = default!;


}
