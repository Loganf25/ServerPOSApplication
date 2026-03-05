
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServerPOSApplication.Models;
using Microsoft.AspNetCore.Authorization;

namespace ServerPOSApplication.Pages.CRUD_Pages.Orders
{
    [Authorize(Roles = "Manager")]
    public class DetailsModel : PageModel
    {
        private readonly ServerPOSApplication.Data.ServerPOSApplicationContext _context;

        public DetailsModel(ServerPOSApplication.Data.ServerPOSApplicationContext context)
        {
            _context = context;
        }

        public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FirstOrDefaultAsync(m => m.Id == id);

            if (order is not null)
            {
                Order = order;

                return Page();
            }

            return NotFound();
        }
    }
}
