using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ServerPOSApplication.Models
{
    [Index(nameof(Name), Name = "Ix_Name", IsUnique = true)]
    public class Discount : IValidatableObject
    {
        [Key]
        public int Id { get; set; }
        [StringLength(25, ErrorMessage = "Name cannot be longer than 25 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Name can only contain letters, numbers, and spaces.")]
        public required string Name { get; set; }
        [RegularExpression("Fixed|Percentage", ErrorMessage = "Type must be either 'Fixed' or 'Percentage'")]
        public required string Type { get; set; } // "Percentage" or "FixedAmount
        public int Value { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Type == "Percentage")
            {
                if (Value < 0 || Value > 100)
                {
                    yield return new ValidationResult("For percentage discounts, value must be between 0 and 100.", new[] { nameof(Value) });
                }
                if (Value % 1 != 0)
                {
                    yield return new ValidationResult("For percentage discounts, value must be a whole number.", new[] { nameof(Value) });
                }
                
            }
            else if (Type == "Fixed")
            {
                if (Value < 0 || Value > 100)
                {
                    yield return new ValidationResult("For fixed amount discounts, value cannot be negative.", new[] { nameof(Value) });
                }
                if (decimal.Round(Value, 2) != Value)
                {
                    yield return new ValidationResult("For fixed amount discounts, value cannot have more than 2 decimal places.", new[] { nameof(Value) });
                }
            }
        }
}
