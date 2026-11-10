#if false
using System;

namespace DelegateApp
{
    public delegate double Operation(double a, double b);

    class Program
    {
        static double Add(double x, double y) => x + y;
        static double Multiply(double x, double y) => x * y;
        /*
        static void Main(string[] args)
        {
            Operation op = Add;
            Console.WriteLine($"Add: {op(10, 5)}");

            op = Multiply;
            Console.WriteLine($"Multiply: {op(10, 5)}");
        }
        */
    }
}

#endif

