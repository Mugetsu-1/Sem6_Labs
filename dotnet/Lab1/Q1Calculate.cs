using System;

namespace CalculateApp
{
    class Calculate
    {
        public int num1, num2;

        public void setData(int x, int y)
        {
            num1 = x;
            num2 = y;
        }

        public void FindSum() => Console.WriteLine($"Sum = {num1 + num2}");

        public int FindMulti() => num1 * num2;

        public void FindDifference() => Console.WriteLine($"Difference = {num1 - num2}");
    }
}