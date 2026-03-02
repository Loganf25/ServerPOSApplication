using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServerPOSApplication.Data;
using ServerPOSApplication.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace ServerPOSApplication.Pages.CRUD_Pages.Employees
{
    public class FinishProfileModel : PageModel
    {
        private readonly ServerPOSApplication.Data.ServerPOSApplicationContext _context; 

        public FinishProfileModel(ServerPOSApplicationContext context)
        {
            _context = context; 
        }

        // Input from html page
        [BindProperty]
        public required InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "First Name")]
            public required string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public required string LastName { get; set; }
        }
        // Create Employee object here to sync with Indentity Profile
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); 
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null) return RedirectToPage("/Account/Login", new { area = "Identity" });

            var newEmployee = new Employee
            {
                FirstName = Input.FirstName,
                LastName = Input.FirstName,
                IdentityUserId = userId
            };

            _context.Employees.Add(newEmployee);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }

    }
}
