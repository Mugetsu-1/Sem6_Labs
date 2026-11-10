using System;

namespace PropertyApp
{
    class Employee
    {
        private int id;
        private string name;
        private double salary;

        public int Id
        {
            get => id;
            set { if (value > 0) id = value; else Console.WriteLine("Invalid ID"); }
        }

        public string Name => name;
        public string Department { get; set; }

        public double Salary
        {
            get => salary;
            set { if (value >= 0) salary = value; else Console.WriteLine("Salary cannot be negative"); }
        }

        public string Designation => salary >= 70000 ? "Senior" : salary >= 40000 ? "Mid-Level" : "Junior";

        public Employee(int empId, string empName, double empSalary, string dept)
        { Id = empId; name = empName; Salary = empSalary; Department = dept; }

        public void Display() => Console.WriteLine($"ID: {Id}\nName: {Name}\nSalary: {Salary}\nDepartment: {Department}\nDesignation: {Designation}");
    }
}