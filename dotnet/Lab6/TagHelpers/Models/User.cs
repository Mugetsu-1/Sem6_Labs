using System.ComponentModel.DataAnnotations;

namespace TagHelpers.Models
{
    public class User
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Range(1, 10)]
        public int Rating { get; set; } = 5;
    }
}