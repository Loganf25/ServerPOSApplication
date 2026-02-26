using System.ComponentModel.DataAnnotations;

namespace ServerPOSApplication.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        [StringLength(25, ErrorMessage = "First Name cannot be longer than 25 characters.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First Name can only contain letters.")]
        public required string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [StringLength(25, ErrorMessage = "Last Name cannot be longer than 25 characters.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last Name can only contain letters.")]
        public required string LastName { get; set; }
        public virtual required Credential Credential { get; set; }
    }
}
