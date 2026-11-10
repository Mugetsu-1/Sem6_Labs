using System.Collections.Generic;
using Lab3._3.Models;

namespace Lab3._3.Models
{
    public interface IEmpRepo
    {
        List<Employee> GetAll();
        Employee GetById(int id);
    }
}