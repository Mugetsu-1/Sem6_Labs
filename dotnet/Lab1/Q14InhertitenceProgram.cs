#if false
using System;

namespace MultipleInheritanceApp
{
    interface IEmployee { void ShowEmployee(); }
    interface ISalary { void ShowSalary(); }
    interface IDepartment { void ShowDepartment(); }

    class Manager : IEmployee, ISalary, IDepartment
    {
        public string name; public double salary; public string dept;
        public Manager(string n, double s, string d) { name = n; salary = s; dept = d; }
        public void ShowEmployee() => Console.WriteLine($"Name: {name}");
        public void ShowSalary() => Console.WriteLine($"Salary: {salary}");
        public void ShowDepartment() => Console.WriteLine($"Department: {dept}");
        public void ShowAll() { ShowEmployee(); ShowSalary(); ShowDepartment(); }
    }

    class Program
    {
        /*
        static void Main(string[] args)
        {
            Manager mgr = new Manager("Saugat", 75000, "IT");
            mgr.ShowAll();
        }
        */
    }
}

#endif

