#if false
using System;

namespace Unit1CH1._3
{
    class NamedArgsDemo
    {
        public void Register(string name, int age, string city, string course)
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Age: " + age);
            Console.WriteLine("City: " + city);
            Console.WriteLine("Course: " + course);
            Console.WriteLine();
        }

        public void Calculate(int a, int b, int c)
        {
            int result = a + b - c;
            Console.WriteLine(a + " + " + b + " - " + c + " = " + result);
        }

        public void DisplayInfo(string empName, double salary, int expYears, string dept)
        {
            Console.WriteLine("Employee: " + empName + ", Salary: " + salary + ", Experience: " + expYears + " years, Dept: " + dept);
        }
    }

    internal class ConceptNamedArgument
    {
        /*
        static void Main(string[] args)
        {
            NamedArgsDemo demo = new NamedArgsDemo();

            // Normal positional arguments
            Console.WriteLine("Positional arguments:");
            demo.Register("Saugat", 21, "New York", "Computer Science");

            // Named arguments - order doesn't matter
            Console.WriteLine("Named arguments (different order):");
            demo.Register(course: "Mathematics", city: "Kathmandu", name: "Ram", age: 22);

            // Named arguments with some positional and some named
            Console.WriteLine("Mixed positional and named:");
            demo.Register("Bobbbyyyyy", age: 30, city: "Texas", course: "Physics");

            // Named arguments for clarity
            Console.WriteLine("Using named arguments for clarity:");
            demo.Calculate(c: 10, a: 20, b: 15);
            demo.Calculate(a: 5, c: 3, b: 8);

            // Named arguments with different types
            Console.WriteLine();
            demo.DisplayInfo(empName: "Harry", salary: 75000, expYears: 5, dept: "IT");
            demo.DisplayInfo(dept: "HR", expYears: 3, empName: "Emmy", salary: 65000);
        }
        */
    }
}

#endif

