using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace ServerPOSApplication.Pages
{
    public class PrivacyModel : PageModel
    {
        public void OnGet()
        {
            string dataTime = DateTime.Now.ToString("d", new CultureInfo("en-US"));
            ViewData["TimeStamp"] = dataTime;
        }
    }

}
