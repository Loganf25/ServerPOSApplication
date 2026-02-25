using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerPOSApplication.Models;

namespace ServerPOSApplication.Data
{
    public class ServerPOSApplicationContext : DbContext
    {
        public ServerPOSApplicationContext (DbContextOptions<ServerPOSApplicationContext> options)
            : base(options)
        {
        }
        public DbSet<ServerPOSApplication.Models.Credential> Credential { get; set; } = default!;
        public DbSet<ServerPOSApplication.Models.Discount> Discount { get; set; } = default!;
        public DbSet<ServerPOSApplication.Models.Employee> Employee { get; set; } = default!;
        public DbSet<ServerPOSApplication.Models.MenuItem> MenuItem { get; set; } = default!;
        public DbSet<ServerPOSApplication.Models.OrderItem> OrderItem { get; set; } = default!;
        public DbSet<ServerPOSApplication.Models.Order> Order { get; set; } = default!;
        public DbSet<ServerPOSApplication.Models.Tax> Tax { get; set; } = default!;



    }
}
