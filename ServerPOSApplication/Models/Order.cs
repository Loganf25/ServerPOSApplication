using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerPOSApplication.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public virtual required Employee Employee { get; set; }
        public int SubTotal { get; set; }
        public int AfterTaxTotal { get; set; }
        public int AfterDiscountTotal { get; set; }
        public int FinalTotal { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual required ICollection<OrderItem> OrderItem { get; set; }
    }
}
