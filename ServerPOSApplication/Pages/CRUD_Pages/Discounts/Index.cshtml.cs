using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServerPOSApplication.Data;
using ServerPOSApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPOSApplication.Pages.CRUD_Pages.Discounts
{
    [Authorize(Roles = "Manager")]
    public class IndexModel : PageModel
    {
        private readonly ServerPOSApplication.Data.ServerPOSApplicationContext _context;

        public IndexModel(ServerPOSApplication.Data.ServerPOSApplicationContext context)
        {
            _context = context;
        }

        public IList<Discount> Discount { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Discount = await _context.Discounts.ToListAsync();
        }
    }
}
