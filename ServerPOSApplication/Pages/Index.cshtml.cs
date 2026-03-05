using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServerPOSApplication.Data;
using ServerPOSApplication.Models;
using System.Security.Claims;
using System.Text.Json;

namespace ServerPOSApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ServerPOSApplicationContext _context;
        public IndexModel(ServerPOSApplicationContext context)
        {
            _context = context;
        }

        public List<MenuItem>? MenuItems { get; set; }
        public List<Discount>? Discounts { get; set; }
        public decimal TotalTaxRate { get; set; }

        [BindProperty] public string? OrderData { get; set; }
        [BindProperty] public int? SelectedDiscountId { get; set; }
        public async Task OnGetAsync()
        {
            MenuItems = await _context.MenuItems.ToListAsync();
            Discounts = await _context.Discounts.ToListAsync();

            var taxes = await _context.Taxes.ToListAsync();
            TotalTaxRate = taxes.Sum(t => t.Percentage) / 100m;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(OrderData)) return Page();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.IdentityUserId == userId);

            var cartItems = JsonSerializer.Deserialize<List<CartItemDto>>(OrderData);
            // Guard against null deserialization result to avoid CS8602 on foreach
            if (cartItems == null || cartItems.Count == 0) return Page();

            var order = new Order
            {
                EmployeeId = employee.Id,
                OrderDate = DateTime.Now,
                OrderItem = new List<OrderItem>()
            };

            decimal subTotal = 0;

            foreach (var item in cartItems)
            {
                if (item == null) continue; // defensive: skip any null entries in the list

                var menuInfo = await _context.MenuItems.FindAsync(item.MenuItemId);
                if (menuInfo != null)
                {
                    subTotal += menuInfo.Price * item.Quantity;
                    order.OrderItem.Add(new OrderItem
                    {
                        MenuItemId = menuInfo.Id,
                        Quantity = item.Quantity,
                        PriceAtSale = menuInfo.Price
                    });
                }
            }

            decimal discountAmount = 0;
            if (SelectedDiscountId.HasValue)
            {
                var discount = await _context.Discounts.FindAsync(SelectedDiscountId.Value);
                if (discount != null)
                {
                    discountAmount = discount.Type == "Percentage"
                        ? subTotal * (discount.Value / 100m)
                        : discount.Value;
                }
            }

            var taxes = await _context.Taxes.ToListAsync();
            decimal totalTaxPercentage = taxes.Sum(t => t.Percentage) / 100m;

            order.SubTotal = subTotal;
            order.DiscountAmount = discountAmount;
            order.PreTaxTotal = Math.Max(0, subTotal - discountAmount);
            order.TaxAmount = order.PreTaxTotal * totalTaxPercentage;
            order.FinalTotal = order.PreTaxTotal + order.TaxAmount;

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
    public class CartItemDto
    {
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
    }
}
