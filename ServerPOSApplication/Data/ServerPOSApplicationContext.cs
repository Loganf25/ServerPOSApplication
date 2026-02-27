using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServerPOSApplication.Models;

namespace ServerPOSApplication.Data
{
    public class ServerPOSApplicationContext : IdentityDbContext
    {
        public ServerPOSApplicationContext (DbContextOptions<ServerPOSApplicationContext> options)
            : base(options)
        {
        }
        public DbSet<ServerPOSApplication.Models.Discount> Discounts { get; set; } = default!;
        public DbSet<ServerPOSApplication.Models.Employee> Employees { get; set; } = default!;
        public DbSet<ServerPOSApplication.Models.MenuItem> MenuItems { get; set; } = default!;
        public DbSet<ServerPOSApplication.Models.OrderItem> OrderItems { get; set; } = default!;
        public DbSet<ServerPOSApplication.Models.Order> Orders { get; set; } = default!;
        public DbSet<ServerPOSApplication.Models.Tax> Taxes { get; set; } = default!;



    }
}
