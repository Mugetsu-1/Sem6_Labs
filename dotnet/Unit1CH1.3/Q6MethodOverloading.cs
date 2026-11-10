#if false
using System;

namespace Unit1CH1._3
{
    class Calculator
    {
        // Overloaded methods with different number of parameters
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }

        // Overloaded methods with different parameter types
        public double Add(double a, double b)
        {
            return a + b;
        }

        public string Add(string a, string b)
        {
            return a + b;
        }

        // Overloaded methods with different order of parameters
        public void Display(string name, int age)
        {
            Console.WriteLine("Name: " + name + ", Age: " + age);
        }

        public void Display(int age, string name)
        {
            Console.WriteLine("Age: " + age + ", Name: " + name);
        }
    }

    internal class MethodOverloading
    {
        /*
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            Console.WriteLine("Add(int, int): " + calc.Add(5, 10));
            Console.WriteLine("Add(int, int, int): " + calc.Add(5, 10, 15));
            Console.WriteLine("Add(double, double): " + calc.Add(5.5, 10.5));
            Console.WriteLine("Add(string, string): " + calc.Add("Hello ", "World"));

            Console.WriteLine();
            calc.Display("Saugat", 25);
            calc.Display(30, "Ram");
        }
        */
    }
}

#endif

