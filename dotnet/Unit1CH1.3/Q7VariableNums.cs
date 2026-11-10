#if false
using System;

namespace Unit1CH1._3
{
    class VariableArgsDemo
    {
        // Method with variable number of integer arguments
        public int Sum(params int[] numbers)
        {
            int total = 0;
            foreach (int num in numbers)
            {
                total += num;
            }
            return total;
        }

        // Method with variable number of string arguments
        public void Concat(params string[] words)
        {
            string result = "";
            foreach (string word in words)
            {
                result += word + " ";
            }
            Console.WriteLine("Concatenated: " + result.Trim());
        }

        // Method with regular parameter and params
        public void PrintMessage(string prefix, params int[] values)
        {
            Console.Write(prefix + ": ");
            foreach (int val in values)
            {
                Console.Write(val + " ");
            }
            Console.WriteLine();
        }
    }

    internal class VariableNums
    {
        /*
        static void Main(string[] args)
        {
            VariableArgsDemo demo = new VariableArgsDemo();

            // Passing different number of arguments
            Console.WriteLine("Sum of 2 numbers: " + demo.Sum(10, 20));
            Console.WriteLine("Sum of 4 numbers: " + demo.Sum(5, 10, 15, 20));
            Console.WriteLine("Sum of 6 numbers: " + demo.Sum(1, 2, 3, 4, 5, 6));
            Console.WriteLine("Sum with no arguments: " + demo.Sum());

            Console.WriteLine();
            demo.Concat("Hello", "World");
            demo.Concat("C#", "is", "this programming", "language");
            demo.Concat("This", "is", "a", "test", "message");

            Console.WriteLine();
            demo.PrintMessage("Numbers", 100, 200, 300);
            demo.PrintMessage("Scores", 85, 90, 78, 92, 88);
        }
        */
    }
}

#endif

