#if false
using System;

namespace Unit1CH1._6
{
    // Declare a delegate
    public delegate void MathOperation(int a, int b);

    class MathOps
    {
        public void Add(int x, int y)
        {
            Console.WriteLine($"Addition: {x} + {y} = {x + y}");
        }

        public void Subtract(int x, int y)
        {
            Console.WriteLine($"Subtraction: {x} - {y} = {x - y}");
        }

        public void Multiply(int x, int y)
        {
            Console.WriteLine($"Multiplication: {x} * {y} = {x * y}");
        }
    }

    internal class DelegateDemo
    {
        /*
        static void Main(string[] args)
        {
            MathOps obj = new MathOps();

            // Instantiate the delegate
            MathOperation op = new MathOperation(obj.Add);

            // Invoke the delegate
            Console.WriteLine("Calling delegate with Add:");
            op(10, 5);

            // Reassign delegate to Subtract
            op = obj.Subtract;
            Console.WriteLine("\nCalling delegate with Subtract:");
            op(10, 5);

            // Reassign delegate to Multiply
            op = obj.Multiply;
            Console.WriteLine("\nCalling delegate with Multiply:");
            op(10, 5);
        }
        */
    }
}

#endif

