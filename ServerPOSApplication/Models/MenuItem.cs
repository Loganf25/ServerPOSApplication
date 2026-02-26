using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerPOSApplication.Models
{
    [Index(nameof(Name), Name = "Ix_Name", IsUnique = true)]

    public class MenuItem
    {
        [Key]
        public int Id { get; set; }

        [StringLength(25, ErrorMessage = "Name cannot be longer than 25 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Name can only contain letters, numbers, and spaces.")]
        public required string Name { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [DataType(DataType.Currency)]
        [Range(0.00, 100, ErrorMessage = "Price must be between 0.00 and 100.")]
        public decimal Price { get; set; }

    }
}
