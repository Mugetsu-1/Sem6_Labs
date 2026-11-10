#if false
using System;

namespace Unit1CH1._3
{
    class MethodDemo
    {
        // 1. Method with no parameters and no return value
        public void DisplayMessage()
        {
            Console.WriteLine("Hello from void method");
        }

        // 2. Method with parameters and no return value
        public void AddNumbers(int a, int b)
        {
            int sum = a + b;
            Console.WriteLine("Sum of " + a + " and " + b + " is: " + sum);
        }

        // 3. Method with parameters and return value
        public int MultiplyNumbers(int a, int b)
        {
            return a * b;
        }

        // 4. Method with return value and no parameters
        public string GetGreeting()
        {
            return "Welcome to C# Programming";
        }

        // 5. Static method (belongs to class, not object)
        public static void StaticMethod()
        {
            Console.WriteLine("This is a static method");
        }

        // 6. Method with default parameter values
        public void PrintDetails(string name, int age = 18, string city = "Unknown")
        {
            Console.WriteLine("Name: " + name + ", Age: " + age + ", City: " + city);
        }

        // 7. Method with params array
        public void SumMultipleNumbers(params int[] numbers)
        {
            int total = 0;
            foreach (int num in numbers)
            {
                total += num;
            }
            Console.WriteLine("Sum of all numbers: " + total);
        }

        // 8. Method overloading (same name, different parameters)
        public void Display(int number)
        {
            Console.WriteLine("Integer: " + number);
        }

        public void Display(string text)
        {
            Console.WriteLine("String: " + text);
        }

        public void Display(double value)
        {
            Console.WriteLine("Double: " + value);
        }
    }

    internal class VariousMethods
    {
        /*
        static void Main(string[] args)
        {
            MethodDemo obj = new MethodDemo();

            Console.WriteLine("1. Method with no parameters and no return:");
            obj.DisplayMessage();

            Console.WriteLine("\n2. Method with parameters and no return:");
            obj.AddNumbers(10, 20);

            Console.WriteLine("\n3. Method with parameters and return:");
            int result = obj.MultiplyNumbers(5, 6);
            Console.WriteLine("Product: " + result);

            Console.WriteLine("\n4. Method with return and no parameters:");
            string greeting = obj.GetGreeting();
            Console.WriteLine(greeting);

            Console.WriteLine("\n5. Static method:");
            MethodDemo.StaticMethod();

            Console.WriteLine("\n6. Method with default parameters:");
            obj.PrintDetails("John");
            obj.PrintDetails("Alice", 25);
            obj.PrintDetails("Bob", 30, "New York");

            Console.WriteLine("\n7. Method with params array:");
            obj.SumMultipleNumbers(1, 2, 3, 4, 5);
            obj.SumMultipleNumbers(10, 20, 30);

            Console.WriteLine("\n8. Method overloading:");
            obj.Display(100);
            obj.Display("Hello World");
            obj.Display(99.99);
        }
        */
    }
}

#endif

