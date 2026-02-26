using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServerPOSApplication.Data;
using ServerPOSApplication.Models;

namespace ServerPOSApplication.Pages.CRUD_Pages.MenuItems
{
    public class DetailsModel : PageModel
    {
        private readonly ServerPOSApplication.Data.ServerPOSApplicationContext _context;

        public DetailsModel(ServerPOSApplication.Data.ServerPOSApplicationContext context)
        {
            _context = context;
        }

        public MenuItem MenuItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuitem = await _context.MenuItems.FirstOrDefaultAsync(m => m.Id == id);

            if (menuitem is not null)
            {
                MenuItem = menuitem;

                return Page();
            }

            return NotFound();
        }
    }
}
