using Microsoft.AspNetCore.Mvc;
using Lab4.Models;

namespace Lab4.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Information()
        {
            return Content("Student Management System - Lab4");
        }

        public IActionResult StudentData()
        {
            Student student = new Student
            {
                StudentId = 101,
                Name = "Ram Sharma",
                Address = "Kathmandu",
                Phone = "9841234567",
                Program = "BCA",
                Semester = 5
            };
            return Json(student);
        }

        public IActionResult Empty()
        {
            return new EmptyResult();
        }

        public IActionResult GoToTeacher()
        {
            return Redirect("/Teacher/Index");
        }

        [NonAction]
        public string GetStudentStatus()
        {
            return "Student is active.";
        }

        [ActionName("StudentDetails")]
        public IActionResult StudentInformation()
        {
            return Content("Student Details: Ram Sharma - CSIT - Semester 6");
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Content("Student records are retrieved using HTTP GET.");
        }

        [HttpPost]
        public IActionResult AddStudent()
        {
            return Content("Student record is added using HTTP POST.");
        }
    }
}