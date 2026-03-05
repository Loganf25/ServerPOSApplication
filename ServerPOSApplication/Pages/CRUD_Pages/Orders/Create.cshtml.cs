using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServerPOSApplication.Models;
using Microsoft.AspNetCore.Authorization;

namespace ServerPOSApplication.Pages.CRUD_Pages.Orders
{
    [Authorize(Roles = "Manager")]
    public class CreateModel : PageModel
    {
        private readonly ServerPOSApplication.Data.ServerPOSApplicationContext _context;

        public CreateModel(ServerPOSApplication.Data.ServerPOSApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
