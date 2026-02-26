using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerPOSApplication.Models
{
    [Index(nameof(UserName), Name = "Ix_UserName", IsUnique = true)]
    public class Credential
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [Display(Name = "Username")]
        [StringLength(4, ErrorMessage = "Username must be exactly 4 characters long.", MinimumLength = 4)]
        public required string UserName { get; set; }
        [Display]
        [StringLength(16, ErrorMessage = "Password must be between 4 and 16 characters long.", MinimumLength = 4)]
        public required string PasswordHash { get; set; }
        public virtual Employee Employee { get; set; } = null!;
    }
}
