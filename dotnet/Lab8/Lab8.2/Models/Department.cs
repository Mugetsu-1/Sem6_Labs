using System.ComponentModel.DataAnnotations;

namespace Lab8._2.Models;

// Department entity (Lab question 2)
public class Department
{
    public int Id { get; set; }

    [Required, StringLength(50)]
    public string Name { get; set; } = string.Empty;

    [StringLength(50)]
    [Display(Name = "Head")]
    public string Head { get; set; } = string.Empty;

    [Display(Name = "Established")]
    public int Established { get; set; }
}
