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
    }

public DbSet<QuickRentProject.Models.Item> Item { get; set; } = default!;

public DbSet<QuickRentProject.Models.Booking> Booking { get; set; } = default!;

public DbSet<QuickRentProject.Models.Payment> Payment { get; set; } = default!;

public DbSet<QuickRentProject.Models.Review> Review { get; set; } = default!;
}
