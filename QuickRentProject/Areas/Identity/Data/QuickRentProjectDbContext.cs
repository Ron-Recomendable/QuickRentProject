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
                Role = "Renter",
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
                Role = "Owner",
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
            },
            new QuickRentProjectUser
            {
                Id = "5",
                UserName = "Damian@example.com",
                NormalizedUserName = "DAMIAN@EXAMPLE.COM",
                Email = "Damian@example.com",
                NormalizedEmail = "DAMIAN@EXAMPLE.COM",
                EmailConfirmed = true,
                FirstName = "Damian",
                LastName = "Fletcher",
                PhoneNumber = "5551234567",
                Role = "Owner",
                PasswordHash = hasher.HashPassword(null, "Damian123_"),
            },
            new QuickRentProjectUser
            {
                Id = "6",
                UserName = "Elara@example.com",
                NormalizedUserName = "ELARA@EXAMPLE.COM",
                Email = "Elara@example.com",
                NormalizedEmail = "ELARA@EXAMPLE.COM",
                EmailConfirmed = true,
                FirstName = "Elara",
                LastName = "Whitmore",
                PhoneNumber = "5552345678",
                Role = "Renter",
                PasswordHash = hasher.HashPassword(null, "Elara123_"),
            },
            new QuickRentProjectUser
            {
                Id = "7",
                UserName = "Gregory@example.com",
                NormalizedUserName = "GREGORY@EXAMPLE.COM",
                Email = "Gregory@example.com",
                NormalizedEmail = "GREGORY@EXAMPLE.COM",
                EmailConfirmed = true,
                FirstName = "Gregory",
                LastName = "Holloway",
                PhoneNumber = "5553456789",
                Role = "Renter",
                PasswordHash = hasher.HashPassword(null, "Gregory123_"),
            },
            new QuickRentProjectUser
            {
                Id = "8",
                UserName = "Hazel@example.com",
                NormalizedUserName = "HAZEL@EXAMPLE.COM",
                Email = "Hazel@example.com",
                NormalizedEmail = "HAZEL@EXAMPLE.COM",
                EmailConfirmed = true,
                FirstName = "Hazel",
                LastName = "Bridges",
                PhoneNumber = "5554567890",
                Role = "Owner",
                PasswordHash = hasher.HashPassword(null, "Hazel123_"),
            },
            new QuickRentProjectUser
            {
                Id = "9",
                UserName = "Ivan@example.com",
                NormalizedUserName = "IVAN@EXAMPLE.COM",
                Email = "Ivan@example.com",
                NormalizedEmail = "IVAN@EXAMPLE.COM",
                EmailConfirmed = true,
                FirstName = "Ivan",
                LastName = "Langley",
                PhoneNumber = "5555678901",
                Role = "Renter",
                PasswordHash = hasher.HashPassword(null, "Ivan123_"),
            },
            new QuickRentProjectUser
            {
                Id = "10",
                UserName = "Jasmine@example.com",
                NormalizedUserName = "JASMINE@EXAMPLE.COM",
                Email = "Jasmine@example.com",
                NormalizedEmail = "JASMINE@EXAMPLE.COM",
                EmailConfirmed = true,
                FirstName = "Jasmine",
                LastName = "Everly",
                PhoneNumber = "5556789012",
                Role = "Owner",
                PasswordHash = hasher.HashPassword(null, "Jasmine123_"),
            }
        );
    }

public DbSet<QuickRentProject.Models.Item> Item { get; set; } = default!;

public DbSet<QuickRentProject.Models.Booking> Booking { get; set; } = default!;

public DbSet<QuickRentProject.Models.Payment> Payment { get; set; } = default!;

public DbSet<QuickRentProject.Models.Review> Review { get; set; } = default!;


}
