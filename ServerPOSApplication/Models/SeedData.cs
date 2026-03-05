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

            var serverUserName = "sv01";
            var serverUser = await userManager.FindByNameAsync(serverUserName);
            if (serverUser == null)
            {
                serverUser = new IdentityUser { UserName = serverUserName, Email = "sever1@pos.com" };
                var result = await userManager.CreateAsync(serverUser, "P@ssword123!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(serverUser, "Server");
                    context.Employees.Add(new Employee { FirstName = "Jane", LastName = "Doe", IdentityUserId = serverUser.Id });
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

            if (!context.MenuItems.Any())
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

            if (!context.Orders.Any())
            {
                var employee = context.Employees.FirstOrDefault(e => e.FirstName == "Jane");
                var burger = context.MenuItems.FirstOrDefault(m => m.Name == "Burger");
                var fries = context.MenuItems.FirstOrDefault(m => m.Name == "Fries");
                var coke = context.MenuItems.FirstOrDefault(m => m.Name == "Coke");

                if (employee != null && burger != null && fries != null && coke != null)
                {
                    context.Orders.AddRange(
                        new Order
                        {
                            EmployeeId = employee.Id,
                            SubTotal = burger.Price + fries.Price + coke.Price,
                            DiscountAmount = 0,
                            PreTaxTotal = burger.Price + fries.Price + coke.Price,
                            TaxAmount = (burger.Price + fries.Price + coke.Price) * 0.1m, // Example tax calculation
                            FinalTotal = (burger.Price + fries.Price + coke.Price) * 1.1m, // Example final total calculation
                            OrderDate = DateTime.Now.AddHours(-2),
                            OrderItem = new List<OrderItem>
                            {
                                new OrderItem { MenuItemId = burger.Id, Quantity = 1, PriceAtSale = burger.Price },
                                new OrderItem { MenuItemId = fries.Id, Quantity = 1, PriceAtSale = fries.Price },
                                new OrderItem { MenuItemId = coke.Id, Quantity = 1, PriceAtSale = coke.Price }
                            }
                        },
                        new Order
                        {
                            EmployeeId = employee.Id,
                            SubTotal = burger.Price * 2 + fries.Price * 2 + coke.Price * 2,
                            DiscountAmount = 0,
                            PreTaxTotal = burger.Price * 2 + fries.Price * 2 + coke.Price * 2,
                            TaxAmount = (burger.Price * 2 + fries.Price * 2 + coke.Price * 2) * 0.1m, // Example tax calculation
                            FinalTotal = (burger.Price * 2 + fries.Price * 2 + coke.Price * 2) * 1.1m, // Example final total calculation
                            OrderDate = DateTime.Now.AddDays(-1),
                            OrderItem = new List<OrderItem>
                            {
                                new OrderItem { MenuItemId = burger.Id, Quantity = 2, PriceAtSale = burger.Price },
                                new OrderItem { MenuItemId = fries.Id, Quantity = 2, PriceAtSale = fries.Price },
                                new OrderItem { MenuItemId = coke.Id, Quantity = 2, PriceAtSale = coke.Price }
                            }
                        }
                    );
                }
                context.SaveChanges();
            }
        }
    }
}
