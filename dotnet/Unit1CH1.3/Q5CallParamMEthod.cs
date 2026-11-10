#if false
using System;

namespace Unit1CH1._3
{
    class ParameterDemo
    {
        // 1. Pass by value (default)
        public void PassByValue(int x)
        {
            x = x + 10;
            Console.WriteLine("Inside method (value): " + x);
        }

        // 2. Pass by reference using ref
        public void PassByReference(ref int x)
        {
            x = x + 10;
            Console.WriteLine("Inside method (ref): " + x);
        }

        // 3. Pass by reference using out (for multiple returns)
        public void PassByOut(int x, out int y, out int z)
        {
            y = x * 2;
            z = x * 3;
        }

        // 4. Returning value type
        public int ReturnValue(int a, int b)
        {
            return a + b;
        }

        // 5. Returning multiple values using tuple
        public (int sum, int product) ReturnMultiple(int a, int b)
        {
            return (a + b, a * b);
        }
    }

    internal class CallParamMethod
    {
        /*
        static void Main(string[] args)
        {
            ParameterDemo demo = new ParameterDemo();

            // Pass by value
            int num1 = 5;
            Console.WriteLine("Before pass by value: " + num1);
            demo.PassByValue(num1);
            Console.WriteLine("After pass by value: " + num1);

            Console.WriteLine();

            // Pass by reference (ref)
            int num2 = 5;
            Console.WriteLine("Before pass by ref: " + num2);
            demo.PassByReference(ref num2);
            Console.WriteLine("After pass by ref: " + num2);

            Console.WriteLine();

            // Pass by reference (out)
            int result1, result2;
            demo.PassByOut(5, out result1, out result2);
            Console.WriteLine("Out parameters: " + result1 + ", " + result2);

            Console.WriteLine();

            // Returning single value
            int sum = demo.ReturnValue(10, 20);
            Console.WriteLine("Returned sum: " + sum);

            // Returning multiple values (tuple)
            var results = demo.ReturnMultiple(6, 4);
            Console.WriteLine("Tuple return - Sum: " + results.sum + ", Product: " + results.product);
        }
        */
    }
}

#endif

