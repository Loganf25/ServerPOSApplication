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
        public virtual Employee? Employee { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal SubTotal { get; set; }
        [Display(Name = "Tax Total")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal AfterTaxTotal { get; set; }
        [Display(Name = "Discount Total")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal AfterDiscountTotal { get; set; }
        [Display(Name = "Grand Total")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal FinalTotal { get; set; }
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        public virtual required ICollection<OrderItem> OrderItem { get; set; }
    }
}
