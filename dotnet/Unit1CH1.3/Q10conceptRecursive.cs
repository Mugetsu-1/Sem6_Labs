#if false
using System;

namespace Unit1CH1._3
{
    class RecursionDemo
    {
        // Factorial using recursion
        public int Factorial(int n)
        {
            if (n <= 1)
                return 1;
            return n * Factorial(n - 1);
        }

        // Fibonacci using recursion
        public int Fibonacci(int n)
        {
            if (n <= 1)
                return n;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        // Sum of digits using recursion
        public int SumDigits(int n)
        {
            if (n == 0)
                return 0;
            return (n % 10) + SumDigits(n / 10);
        }

        // Power using recursion
        public int Power(int baseNum, int exponent)
        {
            if (exponent == 0)
                return 1;
            return baseNum * Power(baseNum, exponent - 1);
        }
    }

    internal class ConseptRecursive
    {
        /*
        static void Main(string[] args)
        {
            RecursionDemo demo = new RecursionDemo();

            Console.WriteLine("Factorial of 5: " + demo.Factorial(5));
            Console.WriteLine("Fibonacci of 7: " + demo.Fibonacci(7));
            Console.WriteLine("Sum of digits 1234: " + demo.SumDigits(1234));
            Console.WriteLine("2 raised to 8: " + demo.Power(2, 8));
        }
        */
    }
}

#endif

