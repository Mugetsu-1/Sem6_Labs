using System.ComponentModel.DataAnnotations;

namespace Lab8._2.Models;

// Teacher entity (Lab question 2)
public class Teacher
{
    public int Id { get; set; }

    [Required, StringLength(50)]
    public string Name { get; set; } = string.Empty;

    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Phone, StringLength(15)]
    public string Phone { get; set; } = string.Empty;

    [StringLength(50)]
    public string Subject { get; set; } = string.Empty;
}
