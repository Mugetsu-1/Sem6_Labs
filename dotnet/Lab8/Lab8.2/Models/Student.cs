using System.ComponentModel.DataAnnotations;

namespace Lab8._2.Models;

// Student entity (Lab question 2)
public class Student
{
    public int Id { get; set; }

    [Required, StringLength(50)]
    public string Name { get; set; } = string.Empty;

    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Phone, StringLength(15)]
    public string Phone { get; set; } = string.Empty;

    [StringLength(10)]
    public string Semester { get; set; } = string.Empty;
}
