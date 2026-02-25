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

        public DbSet<ServerPOSApplication.Models.Discount> Discount { get; set; } = default!;
    }
}
