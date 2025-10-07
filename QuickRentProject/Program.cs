using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuickRentProject.Areas.Identity.Data;
using QuickRentProjectDb.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("QuickRentProjectDbContextConnection") ?? throw new InvalidOperationException("Connection string 'QuickRentProjectDbContextConnection' not found.");

builder.Services.AddDbContext<QuickRentProjectDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<QuickRentProjectUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>() // Add this line
    .AddEntityFrameworkStores<QuickRentProjectDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

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

    var adminUser = await userManager.FindByEmailAsync("admin@example.com");
    if (adminUser != null && !await userManager.IsInRoleAsync(adminUser, "Admin"))
    {
        await userManager.AddToRoleAsync(adminUser, "Admin");
    }

}

app.Run();