using System.ComponentModel.DataAnnotations;

namespace Lab10.Models
{
    // Model used by the login form
    public class Login
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        // Set when an unauthenticated user is redirected to the login page
        public string? ReturnUrl { get; set; }
    }
}