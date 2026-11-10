using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controllers
{
    [Controller]
    public class Teacher
    {
        public IActionResult Index()
        {
            return new ViewResult
            {
                ViewName = "Index"
            };
        }

        public IActionResult Information()
        {
            return new ContentResult
            {
                Content = "Teacher: Hari Prasad - Computer Science Department"
            };
        }

        public IActionResult TeacherData()
        {
            return new JsonResult(new
            {
                TeacherId = 201,
                Name = "Harry Karki",
                Department = "Computer Science",
                Designation = "Lecturer"
            });
        }

        [HttpGet]
        public IActionResult GetTeachers()
        {
            return new ContentResult
            {
                Content = "Teacher records are retrieved using HTTP GET."
            };
        }

        [HttpPost]
        public IActionResult AddTeacher()
        {
            return new ContentResult
            {
                Content = "Teacher record is added using HTTP POST."
            };
        }

        [HttpPut]
        public IActionResult UpdateTeacher()
        {
            return new ContentResult
            {
                Content = "Teacher record is updated using HTTP PUT."
            };
        }
    }
}