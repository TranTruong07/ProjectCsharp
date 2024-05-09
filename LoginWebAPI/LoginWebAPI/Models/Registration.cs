
using System.ComponentModel.DataAnnotations;

namespace LoginWebAPI.Models
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
