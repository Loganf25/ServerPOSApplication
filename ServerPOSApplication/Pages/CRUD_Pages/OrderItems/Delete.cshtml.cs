using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServerPOSApplication.Models;
using Microsoft.AspNetCore.Authorization;

namespace ServerPOSApplication.Pages.CRUD_Pages.OrderItems
{
    [Authorize(Roles = "Manager")]
    public class DeleteModel : PageModel
    {
        private readonly ServerPOSApplication.Data.ServerPOSApplicationContext _context;

        public DeleteModel(ServerPOSApplication.Data.ServerPOSApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OrderItem OrderItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderitem = await _context.OrderItems.FirstOrDefaultAsync(m => m.Id == id);

            if (orderitem is not null)
            {
                OrderItem = orderitem;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderitem = await _context.OrderItems.FindAsync(id);
            if (orderitem != null)
            {
                OrderItem = orderitem;
                _context.OrderItems.Remove(OrderItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
