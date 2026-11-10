#if false
using System;

namespace Unit1CH1._3
{
    class OptionalArgsDemo
    {
        // Method with optional parameters
        public void RegisterStudent(string name, int age = 18, string course = "Computer Science", double fee = 0.0)
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Age: " + age);
            Console.WriteLine("Course: " + course);
            Console.WriteLine("Fee: " + fee);
            Console.WriteLine();
        }

        // Method with some required and some optional parameters
        public void CalculateSalary(string empName, double baseSalary, double bonus = 0, double tax = 0.10)
        {
            double netSalary = baseSalary + bonus - (baseSalary * tax);
            Console.WriteLine(empName + " - Net Salary: " + netSalary);
        }

        // Method with optional parameters of different types
        public void DisplayInfo(string title, int id = 0, bool isActive = true, string status = "Pending")
        {
            Console.WriteLine("Title: " + title + ", ID: " + id + ", Active: " + isActive + ", Status: " + status);
        }
    }

    internal class OptionalArgument
    {
        /*
        static void Main(string[] args)
        {
            OptionalArgsDemo demo = new OptionalArgsDemo();

            Console.WriteLine("Using all default values:");
            demo.RegisterStudent("John");

            Console.WriteLine("Providing age only:");
            demo.RegisterStudent("Alice", 22);

            Console.WriteLine("Providing age and course:");
            demo.RegisterStudent("Bob", 20, "Mathematics");

            Console.WriteLine("Providing all parameters:");
            demo.RegisterStudent("Charlie", 25, "Physics", 15000.50);

            Console.WriteLine("Salary calculations:");
            demo.CalculateSalary("David", 50000);
            demo.CalculateSalary("Emma", 60000, 5000);
            demo.CalculateSalary("Frank", 70000, 10000, 0.15);

            Console.WriteLine("Display info with different defaults:");
            demo.DisplayInfo("Project A");
            demo.DisplayInfo("Project B", 101);
            demo.DisplayInfo("Project C", 102, false);
            demo.DisplayInfo("Project D", 103, true, "Completed");
        }
        */
    }
}

#endif

