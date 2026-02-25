using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServerPOSApplication.Data;
using ServerPOSApplication.Models;

namespace ServerPOSApplication.Pages.CRUD_Pages.Credentials
{
    public class CreateModel : PageModel
    {
        private readonly ServerPOSApplication.Data.ServerPOSApplicationContext _context;

        public CreateModel(ServerPOSApplication.Data.ServerPOSApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["EmployeeId"] = new SelectList(_context.Set<Employee>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Credential Credential { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Credential.Add(Credential);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
