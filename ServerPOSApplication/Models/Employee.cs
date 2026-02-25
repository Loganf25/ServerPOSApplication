using System.ComponentModel.DataAnnotations;

namespace ServerPOSApplication.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public virtual required Credential Credential { get; set; }
    }
}
