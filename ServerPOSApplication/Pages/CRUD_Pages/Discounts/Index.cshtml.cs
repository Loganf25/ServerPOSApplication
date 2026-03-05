using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServerPOSApplication.Models;

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
