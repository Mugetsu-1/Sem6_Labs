using System.Collections.Generic;
using System.Linq;
using Lab3._3.Models;

namespace Lab3._3.Models
{
    public class MEmpRepo : IEmpRepo
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Saugat", Department = "IT", Salary = 75000 },
            new Employee { Id = 2, Name = "Ello", Department = "HR", Salary = 65000 }
        };

        public List<Employee> GetAll()
        {
            return employees;
        }

        public Employee GetById(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }
    }
}