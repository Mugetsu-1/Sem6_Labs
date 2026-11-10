#if false
using System;

namespace BaseKeywordApp
{
    class Person
    {
        public int id; public string name; public int age;
        public Person(int id, string name, int age) { this.id = id; this.name = name; this.age = age; }
        public void DisplayPerson() => Console.WriteLine($"ID: {id}\nName: {name}\nAge: {age}");
    }

    class Employee : Person
    {
        public string department; public double salary;
        public Employee(int id, string name, int age, string department, double salary) : base(id, name, age)
        { this.department = department; this.salary = salary; }
        public void DisplayEmployee() { DisplayPerson(); Console.WriteLine($"Department: {department}\nSalary: ${salary}"); }
    }

    class Manager : Employee
    {
        public int teamSize;
        public Manager(int id, string name, int age, string department, double salary, int teamSize) : base(id, name, age, department, salary)
        { this.teamSize = teamSize; }
        public void DisplayManager() { DisplayEmployee(); Console.WriteLine($"Team Size: {teamSize} members"); }
    }

    class Program
    {
        /*
        static void Main(string[] args)
        {
            Manager mgr = new Manager(101, "Saugat Thapa", 21, "IT", 85000, 12);
            mgr.DisplayManager();
        }
        */
    }
}

#endif

