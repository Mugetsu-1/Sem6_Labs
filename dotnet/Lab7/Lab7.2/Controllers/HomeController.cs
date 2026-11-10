using ADO.Data;
using ADO.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADO.Controllers
{
    // The controller only handles HTTP and delegates ALL database logic
    // to Data/Emprepository.cs (Lab question 2).
    public class HomeController : Controller
    {
        private readonly Emprepository _empRepository;

        public HomeController(Emprepository empRepository)
        {
            _empRepository = empRepository;
        }

        public IActionResult Index()
        {
            List<Employee> employees = _empRepository.GetAllEmployees();
            return View(employees);
        }

        public IActionResult Details(int id)
        {
            Employee employee = _empRepository.GetEmployeeById(id);
            return View(employee);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _empRepository.AddEmployee(employee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Employee employee = _empRepository.GetEmployeeById(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            _empRepository.UpdateEmployee(employee);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _empRepository.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
