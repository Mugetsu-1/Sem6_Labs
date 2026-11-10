using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Information()
        {
            return Content("Employee Management System - College Staff");
        }

        public IActionResult EmployeeData()
        {
            var employee = new
            {
                EmployeeId = 301,
                Name = "Saugat Thapa",
                Department = "Administration",
                Designation = "Office Assistant"
            };
            return Json(employee);
        }

        [HttpDelete]
        public IActionResult DeleteEmployee()
        {
            return Content("Employee record is deleted using HTTP DELETE.");
        }
    }
}