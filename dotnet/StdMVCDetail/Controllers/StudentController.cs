using Microsoft.AspNetCore.Mvc;
using StdMVCDetail.Models;

namespace StdMVCDetail.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Heading"] = "Student List";
            return View(StudentRepo.GetAll());
        }

        public IActionResult Details(int id)
        {
            Student stu = StudentRepo.GetById(id);
            if (stu == null)
            {
                return NotFound();
            }
            return View(stu);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Student());
        }

        [HttpPost]
        public IActionResult Create(Student stu)
        {
            if (ModelState.IsValid)
            {
                StudentRepo.Add(stu);
                TempData["msg"] = "Student added successfully.";
                return RedirectToAction("Index");
            }
            return View(stu);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student stu = StudentRepo.GetById(id);
            if (stu == null)
            {
                return NotFound();
            }
            return View(stu);
        }

        [HttpPost]
        public IActionResult Edit(int id, Student stu)
        {
            if (ModelState.IsValid)
            {
                stu.Id = id;
                StudentRepo.Update(stu);
                TempData["msg"] = "Student updated successfully.";
                return RedirectToAction("Index");
            }
            return View(stu);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Student stu = StudentRepo.GetById(id);
            if (stu == null)
            {
                return NotFound();
            }
            return View(stu);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            StudentRepo.Delete(id);
            TempData["msg"] = "Student deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
