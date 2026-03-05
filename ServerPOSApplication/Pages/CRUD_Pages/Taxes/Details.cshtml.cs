using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServerPOSApplication.Models;
using Microsoft.AspNetCore.Authorization;

namespace ServerPOSApplication.Pages.CRUD_Pages.Taxes
{
    [Authorize(Roles = "Manager")]
    public class DetailsModel : PageModel
    {
        private readonly ServerPOSApplication.Data.ServerPOSApplicationContext _context;

        public DetailsModel(ServerPOSApplication.Data.ServerPOSApplicationContext context)
        {
            _context = context;
        }

        public Tax Tax { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tax = await _context.Taxes.FirstOrDefaultAsync(m => m.Id == id);

            if (tax is not null)
            {
                Tax = tax;

                return Page();
            }

            return NotFound();
        }
    }
}
