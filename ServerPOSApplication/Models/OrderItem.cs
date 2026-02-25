using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerPOSApplication.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        [ForeignKey("MenuItem")]
        public int MenuItemId { get; set; }
        public virtual required MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }

        public decimal PriceAtSale { get; set; }
    }
}
