#if false
using System;

namespace Unit1CH1._3
{
    class ArrayDemo
    {
        public void DisplayArray(int[] arr)
        {
            Console.Write("Array elements: ");
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        public int FindMax(int[] arr)
        {
            int max = arr[0];
            foreach (int num in arr)
            {
                if (num > max)
                    max = num;
            }
            return max;
        }

        public int FindMin(int[] arr)
        {
            int min = arr[0];
            foreach (int num in arr)
            {
                if (num < min)
                    min = num;
            }
            return min;
        }

        public int SumArray(int[] arr)
        {
            int sum = 0;
            foreach (int num in arr)
            {
                sum += num;
            }
            return sum;
        }

        public double AverageArray(int[] arr)
        {
            return (double)SumArray(arr) / arr.Length;
        }

        public void ReverseArray(int[] arr)
        {
            Console.Write("Reversed array: ");
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }

    internal class Onedimensionarray
    {
        /*
        static void Main(string[] args)
        {
            ArrayDemo demo = new ArrayDemo();

            // Different ways to create arrays
            int[] numbers1 = new int[5];  // Array of size 5
            int[] numbers2 = new int[] { 10, 20, 30, 40, 50 };  // Initialize with values
            int[] numbers3 = { 5, 15, 25, 35, 45, 55, 65 };  // Short syntax
            int[] numbers4 = new int[3] { 100, 200, 300 };  // Explicit size

            Console.WriteLine("Array 1 (default values):");
            demo.DisplayArray(numbers1);

            Console.WriteLine("\nArray 2:");
            demo.DisplayArray(numbers2);
            Console.WriteLine("Sum: " + demo.SumArray(numbers2));
            Console.WriteLine("Average: " + demo.AverageArray(numbers2));
            Console.WriteLine("Maximum: " + demo.FindMax(numbers2));
            Console.WriteLine("Minimum: " + demo.FindMin(numbers2));

            Console.WriteLine("\nArray 3:");
            demo.DisplayArray(numbers3);
            Console.WriteLine("Sum: " + demo.SumArray(numbers3));
            Console.WriteLine("Average: " + demo.AverageArray(numbers3));
            demo.ReverseArray(numbers3);

            Console.WriteLine("\nAccessing individual elements:");
            Console.WriteLine("First element of Array 4: " + numbers4[0]);
            Console.WriteLine("Second element: " + numbers4[1]);
            Console.WriteLine("Third element: " + numbers4[2]);

            // Modifying array elements
            Console.WriteLine("\nModifying Array 2:");
            Console.WriteLine("Before: " + numbers2[2]);
            numbers2[2] = 100;
            Console.WriteLine("After changing index 2 to 100: " + numbers2[2]);
            demo.DisplayArray(numbers2);

            // Array properties
            Console.WriteLine("\nArray properties:");
            Console.WriteLine("Length of Array 3: " + numbers3.Length);
            Console.WriteLine("First element: " + numbers3[0]);
            Console.WriteLine("Last element: " + numbers3[numbers3.Length - 1]);
        }
        */
    }
}

#endif

