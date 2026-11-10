#if false
using System;

namespace Unit1CH1._3
{
    class Employee
    {
        public string name;
        public int id;
        public double salary;

        public Employee()
        {
            name = "Unknown";
            id = 0;
            salary = 0.0;
        }

        // Constructor with one parameter
        public Employee(string empName)
        {
            name = empName;
            id = 0;
            salary = 0.0;
        }

        // Constructor with two parameters
        public Employee(string empName, int empId)
        {
            name = empName;
            id = empId;
            salary = 0.0;
        }

        // Constructor with three parameters
        public Employee(string empName, int empId, double empSalary)
        {
            name = empName;
            id = empId;
            salary = empSalary;
        }

        public void Display()
        {
            Console.WriteLine("Name: " + name + ", ID: " + id + ", Salary: " + salary);
        }
    }

    internal class ConsOverloading
    {
        /*
        static void Main(string[] args)
        {
            Employee emp1 = new Employee();
            Employee emp2 = new Employee("ello");
            Employee emp3 = new Employee("Hari", 101);
            Employee emp4 = new Employee("Ram", 102, 50000.50);

            Console.WriteLine("Employee 1 (Default):");
            emp1.Display();

            Console.WriteLine("Employee 2 (One parameter):");
            emp2.Display();

            Console.WriteLine("Employee 3 (Two parameters):");
            emp3.Display();

            Console.WriteLine("Employee 4 (Three parameters):");
            emp4.Display();
        }
        */
    }
}

#endif

