using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServerPOSApplication.Models;
namespace ServerPOSApplication.Pages.CRUD_Pages.OrderItems
{
    [Authorize(Roles = "Manager")]
    public class IndexModel : PageModel
    {
        private readonly ServerPOSApplication.Data.ServerPOSApplicationContext _context;

        public IndexModel(ServerPOSApplication.Data.ServerPOSApplicationContext context)
        {
            _context = context;
        }

        public IList<OrderItem> OrderItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            OrderItem = await _context.OrderItems
                .Include(o => o.MenuItem).ToListAsync();
        }
    }
}
