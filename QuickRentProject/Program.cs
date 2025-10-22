using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuickRentProject.Areas.Identity.Data;
using QuickRentProjectDb.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("QuickRentProjectDbContextConnection") ?? throw new InvalidOperationException("Connection string 'QuickRentProjectDbContextConnection' not found.");

builder.Services.AddDbContext<QuickRentProjectDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<QuickRentProjectUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<QuickRentProjectDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    string[] roles = { "Owner", "Renter", "Admin" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<QuickRentProjectUser>>();

    // Ensure default Admin user exists
    var adminEmail = "admin@example.com";
    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        adminUser = new QuickRentProjectUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            FirstName = "Admin",
            LastName = "User",
            PhoneNumber = "0000000000",
            Role = "Admin",
            EmailConfirmed = true // Allow immediate login with RequireConfirmedAccount = true
        };

        var createResult = await userManager.CreateAsync(adminUser, "Admin#12345");
        if (!createResult.Succeeded)
        {
            // Optionally log errors here
        }
    }

    if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
    {
        await userManager.AddToRoleAsync(adminUser, "Admin");
    }

    // Optionally keep role assignments for sample users if they exist
    var ownerUser = await userManager.FindByEmailAsync("owner@example.com");
    if (ownerUser != null && !await userManager.IsInRoleAsync(ownerUser, "Owner"))
    {
        await userManager.AddToRoleAsync(ownerUser, "Owner");
    }

    var renterUser = await userManager.FindByEmailAsync("renter@example.com");
    if (renterUser != null && !await userManager.IsInRoleAsync(renterUser, "Renter"))
    {
        await userManager.AddToRoleAsync(renterUser, "Renter");
    }
}

app.Run();