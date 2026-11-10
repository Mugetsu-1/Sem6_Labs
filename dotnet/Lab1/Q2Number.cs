using System;

namespace NumberApp
{
    class Number
    {
        public int x, y;

        public Number() { x = 0; y = 0; }
        public Number(int a, int b) { x = a; y = b; }

        public void DecideEven()
        {
            Console.Write($"Even numbers between {x} and {y}: ");
            for (int i = x; i <= y; i++)
                if (i % 2 == 0) Console.Write(i + " ");
            Console.WriteLine();
        }

        public void DecideOdd()
        {
            Console.Write($"Odd numbers between {x} and {y}: ");
            for (int i = x; i <= y; i++)
                if (i % 2 != 0) Console.Write(i + " ");
            Console.WriteLine();
        }
    }
}