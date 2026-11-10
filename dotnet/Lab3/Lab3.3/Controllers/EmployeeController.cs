using Microsoft.AspNetCore.Mvc;
using Lab3._3.Models;

namespace Lab3._3.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmpRepo _repo;

        public EmployeeController(IEmpRepo repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View("Employee", _repo.GetAll());
        }

        public IActionResult Details(int id)
        {
            var employee = _repo.GetById(id);
            if (employee == null) return NotFound();
            return View(employee);
        }
    }
}