using Lab5.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>
        {
            new Student
            {
                StudentId = 1,
                Name = "Ram Prasad",
                Address = "Kathmandu",
                Phone = "9841234567",
                Program = "BBA",
                Semester = 5,
                GPA = 3.45
            },
            new Student
            {
                StudentId = 2,
                Name = "Sita Karan",
                Address = "Lalitpur",
                Phone = "9851234567",
                Program = "BCA",
                Semester = 6,
                GPA = 3.80
            },
            new Student
            {
                StudentId = 3,
                Name = "Saugat Thapa",
                Address = "Kathmandu",
                Phone = "9861234567",
                Program = "BSc CSIT",
                Semester = 4,
                GPA = 2.95
            }
        };

        public IActionResult Index()
        {
            ViewData["Title"] = "Student List";
            ViewData["College"] = "ACHS College";
            ViewData["TotalStudents"] = students.Count;
            ViewBag.Message = "Welcome to the Student Management System";
            ViewBag.CurrentYear = DateTime.Now.Year;
            return View(students);
        }

        public IActionResult Details(int id)
        {
            var student = students.FirstOrDefault(s => s.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Student Details";
            ViewBag.PageMessage = "Detailed information about the student";
            return View(student);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Title"] = "Add Student";
            ViewBag.Programs = new List<string>
            {
                "BCA",
                "BSc CSIT",
                "BIT",
                "BIM"
            };
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.StudentId = students.Count + 1;
                students.Add(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }
    }
}