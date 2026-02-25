using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerPOSApplication.Models
{
    public class Credential
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public required string UserName { get; set; }
        public required string PasswordHash { get; set; }
        public virtual Employee Employee { get; set; } = null!;
    }
}
