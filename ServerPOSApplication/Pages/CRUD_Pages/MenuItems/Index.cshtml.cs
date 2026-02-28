using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServerPOSApplication.Data;
using ServerPOSApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPOSApplication.Pages.CRUD_Pages.MenuItems
{
    [Authorize(Roles = "Manager")]
    public class IndexModel : PageModel
    {
        private readonly ServerPOSApplication.Data.ServerPOSApplicationContext _context;

        public IndexModel(ServerPOSApplication.Data.ServerPOSApplicationContext context)
        {
            _context = context;
        }

        public IList<MenuItem> MenuItem { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Names { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MenuItemName { get; set; }

        public async Task OnGetAsync()
        {
            var menuItems = from m in _context.MenuItems
                            select m;

            if(!string.IsNullOrEmpty(SearchString))
            {
                menuItems = menuItems.Where(s => s.Name.Contains(SearchString));
            }
            MenuItem = await menuItems.ToListAsync();
        }
    }
}
