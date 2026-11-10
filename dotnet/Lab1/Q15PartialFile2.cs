using System;

namespace PartialClassApp
{
    public partial class Calculator
    {
        public int Multiply(int a, int b) => a * b;
        public int Divide(int a, int b) => b != 0 ? a / b : 0;
    }
}