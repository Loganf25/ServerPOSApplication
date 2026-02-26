using Microsoft.EntityFrameworkCore;
using ServerPOSApplication.Data;

namespace ServerPOSApplication.Models;

public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ServerPOSApplicationContext(
                serviceProvider.GetRequiredService<DbContextOptions<ServerPOSApplicationContext>>()))
        {
            if (context == null || context.Discounts == null || context.Credentials == null || context.Employees == null
                    || context.MenuItems == null || context.Orders == null || context.OrderItems == null || context.Taxes == null)
            {
                throw new ArgumentNullException("Null ServerPOSApplicationContext");
            }

            // Look for any Employees or FoodItems
            if (context.Employees.Any() || context.MenuItems.Any())
            {
                return;   // DB has been seeded
            }

             context.Employees.AddRange(
                 new Employee
                 {
                     FirstName = "John",
                     LastName = "Doe",
                     Credential = new Credential
                     {
                         UserName = "jd01",
                         PasswordHash = "hashedpassword"
                     }
                 },
                 new Employee
                 {
                     FirstName = "James",
                     LastName = "Brown",
                     Credential = new Credential
                     {
                         UserName = "jb01",
                         PasswordHash = "hashedpassword1"
                     }
                 });

            context.Discounts.AddRange(
                new Discount { Name = "Veteran Discount", Type = "Percentage", Value = 20 },
                new Discount { Name = "Employee Discount", Type = "Percentage", Value = 50 },
                new Discount { Name = "New Years Discount", Type = "Fixed", Value = 15 });

            context.Taxes.AddRange(
                new Tax { Name = "City Tax", Percentage = 1 },
                new Tax { Name = "Faulkner County Tax", Percentage = 2 },
                new Tax { Name = "Arkansas Tax", Percentage = 7 });

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

            context.SaveChanges();
            
        }
    }
}
