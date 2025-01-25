using LMS10_1.Data;
using LMS10_1.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LMS10_1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Configure Database Context
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("constr") ??
                    throw new Exception("Database connection string is not configured."));
            });

            // Configure Identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add session services
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout duration
                options.Cookie.HttpOnly = true;                // Secure cookies
                options.Cookie.IsEssential = true;             // Essential cookies
            });

            var app = builder.Build();

            // Run database migrations and seed roles/users
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                try
                {
                    await context.Database.MigrateAsync();
                    await CreateRolesAndAdminUserAsync(roleManager, userManager);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred during migration or role/user seeding: {ex.Message}");
                    throw;
                }
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Add session middleware
            app.UseSession();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            // Map routes for Teacher area
            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            // Default route for other cases
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        // Implementing the CreateRolesAndAdminUserAsync method
        private static async Task CreateRolesAndAdminUserAsync(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            // Define roles to be created
            string[] roles = { "Admin", "Teacher", "User" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    var roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                    if (!roleResult.Succeeded)
                    {
                        Console.WriteLine($"Error creating role '{role}': {string.Join(", ", roleResult.Errors.Select(e => e.Description))}");
                    }
                }
            }

            // Create Admin user if it doesn't exist
            var adminUser = await userManager.FindByEmailAsync("admin@example.com");
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                    FirstName = "Admin",
                    LastName = "User",
                };

                var userResult = await userManager.CreateAsync(adminUser, "AdminPassword123!");
                if (userResult.Succeeded)
                {
                    var roleAssignResult = await userManager.AddToRoleAsync(adminUser, "Admin");
                    if (!roleAssignResult.Succeeded)
                    {
                        Console.WriteLine($"Error assigning 'Admin' role to user: {string.Join(", ", roleAssignResult.Errors.Select(e => e.Description))}");
                    }
                }
                else
                {
                    Console.WriteLine($"Error creating admin user: {string.Join(", ", userResult.Errors.Select(e => e.Description))}");
                }
            }
        }
    }
}
