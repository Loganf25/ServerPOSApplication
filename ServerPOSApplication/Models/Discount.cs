using System.ComponentModel.DataAnnotations;

namespace ServerPOSApplication.Models
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; } // "Percentage" or "FixedAmount"
        public int Value { get; set; }
    }
}
