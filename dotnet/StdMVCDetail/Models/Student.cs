using System.ComponentModel.DataAnnotations;

namespace StdMVCDetail.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string RollNo { get; set; }

        [Required]
        public string Dept { get; set; }

        [Range(1, 8)]
        public int Semester { get; set; }
    }
}
