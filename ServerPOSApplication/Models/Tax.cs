using System.ComponentModel.DataAnnotations;

namespace ServerPOSApplication.Models
{
    public class Tax
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Percentage { get; set; }
    }
}
