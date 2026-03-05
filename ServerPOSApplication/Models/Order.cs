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

        [Display(Name = "Sub Total")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal SubTotal { get; set; }

        [Display(Name = "Discount Amount")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DiscountAmount { get; set; }
       
        [Display(Name = "Pre-Tax Total")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PreTaxTotal { get; set; }

        [Display(Name = "Tax Amount")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TaxAmount { get; set; }

        [Display(Name = "Grand Total")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal FinalTotal { get; set; }

        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        public virtual required ICollection<OrderItem> OrderItem { get; set; }
    }
}
