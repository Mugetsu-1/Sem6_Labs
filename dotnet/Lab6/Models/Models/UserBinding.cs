using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Models.Models
{
    public class UserBinding
    {
        [BindRequired]
        [Required]
        [StringLength(30)]
        public string Name { get; set; } = null!;

        [BindRequired]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Range(18, 60)]
        public int Age { get; set; }

        [BindNever]
        public string Secret { get; set; } = "hidden";
    }
}