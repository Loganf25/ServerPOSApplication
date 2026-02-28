using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServerPOSApplication.Data;

namespace ServerPOSApplication.Models;

public class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ServerPOSApplicationContext(
                serviceProvider.GetRequiredService<DbContextOptions<ServerPOSApplicationContext>>()))
        {
            if (context == null || context.Discounts == null || context.Employees == null
                    || context.MenuItems == null || context.Orders == null || context.OrderItems == null || context.Taxes == null)
            {
                throw new ArgumentNullException("Null ServerPOSApplicationContext");
            }

        
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string[] roleNames = { "Manager", "Server" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var managerUserName = "mg01";
            var managerUser = await userManager.FindByNameAsync(managerUserName);

            if (managerUser == null)
            {
                managerUser = new IdentityUser { UserName = managerUserName, Email = "manager@pos.com" };
                var result = await userManager.CreateAsync(managerUser, "Admin123!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(managerUser, "Manager");

                    context.Employees.Add(new Employee { FirstName = "System", LastName = "Manager", IdentityUserId = managerUser.Id });
                }
              
            }

            if (!context.Discounts.Any())
            {
                context.Discounts.AddRange(
                    new Discount { Name = "Veteran Discount", Type = "Percentage", Value = 20 },
                    new Discount { Name = "Employee Discount", Type = "Percentage", Value = 50 },
                    new Discount { Name = "New Years Discount", Type = "Fixed", Value = 15 });
            }

            if (!context.Taxes.Any())
            {
                context.Taxes.AddRange(
                    new Tax { Name = "City Tax", Percentage = 1 },
                    new Tax { Name = "Faulkner County Tax", Percentage = 2 },
                    new Tax { Name = "Arkansas Tax", Percentage = 7 });
            }

            if (!context.Orders.Any())
            {
                context.MenuItems.AddRange(
                    new MenuItem { Name = "Burger", Price = 12.99m },
                    new MenuItem { Name = "Fries", Price = 2.99m },
                    new MenuItem { Name = "Coke", Price = 1.99m },
                    new MenuItem { Name = "Dr. Pepper", Price = 1.99m },
                    new MenuItem { Name = "Pepsi", Price = 1.99m },
                    new MenuItem { Name = "Water", Price = 0.00m },
                    new MenuItem { Name = "Lemonade", Price = 1.99m },
                    new MenuItem { Name = "Sweet Tea", Price = 2.99m },
                    new MenuItem { Name = "Unsweet Tea", Price = 2.99m },
                    new MenuItem { Name = "Salad", Price = 4.99m },
                    new MenuItem { Name = "Chicken Sandwich", Price = 10.99m },
                    new MenuItem { Name = "Fish Sandwich", Price = 11.99m },
                    new MenuItem { Name = "Onion Rings", Price = 3.99m },
                    new MenuItem { Name = "Mozzarella Sticks", Price = 4.99m }
                );
            }

            context.SaveChanges();
            
        }
    }
}
