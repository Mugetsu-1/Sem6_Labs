using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace StdFormMVC.Models
{
    [DebuggerDisplay("Name: {Name}, Roll: {RollNo}, Age: {Age}, Dept: {Department}, Addr: {Address}, GPA: {GPA}")]
    public class Student
    {
        [Required, Display(Name = "Student Name")]
        public string Name { get; set; } = string.Empty;

        [Required, Display(Name = "Roll No")]
        public string RollNo { get; set; } = string.Empty;

        [Required, Range(1, 100)]
        public int Age { get; set; }

        [Required]
        public string Department { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required, Range(0, 4)]
        public double GPA { get; set; }
    }
}