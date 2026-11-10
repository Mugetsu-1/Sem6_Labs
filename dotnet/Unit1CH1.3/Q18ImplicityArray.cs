#if false
using System;

namespace Unit1CH1._3
{
    class ImplicitArrayDemo
    {
        public void DisplayArray<T>(T[] arr)
        {
            Console.Write("Array elements: ");
            foreach (T item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }

    internal class ImplicityArray
    {
        /*
        static void Main(string[] args)
        {
            ImplicitArrayDemo demo = new ImplicitArrayDemo();

            // Implicitly typed arrays using 'var'
            var numbers = new[] { 10, 20, 30, 40, 50 };
            var names = new[] { "John", "Alice", "Bob" };
            var decimals = new[] { 1.5, 2.7, 3.9, 4.1 };
            var bools = new[] { true, false, true, false };
            var mixed = new[] { 5, 10, 15, 20 };

            Console.WriteLine("Integer array:");
            demo.DisplayArray(numbers);
            Console.WriteLine("Type: " + numbers.GetType());

            Console.WriteLine("\nString array:");
            demo.DisplayArray(names);
            Console.WriteLine("Type: " + names.GetType());

            Console.WriteLine("\nDouble array:");
            demo.DisplayArray(decimals);
            Console.WriteLine("Type: " + decimals.GetType());

            Console.WriteLine("\nBoolean array:");
            demo.DisplayArray(bools);
            Console.WriteLine("Type: " + bools.GetType());

            // Implicitly typed array with different values
            var scores = new[] { 85, 90, 78, 92, 88 };
            Console.WriteLine("\nScores array:");
            demo.DisplayArray(scores);
            Console.WriteLine("Sum: " + scores.Sum());
            Console.WriteLine("Average: " + scores.Average());
            Console.WriteLine("Max: " + scores.Max());
            Console.WriteLine("Min: " + scores.Min());

            // Implicitly typed array with string values
            var cities = new[] { "Kathmandu", "Pokhara", "Chitwan", "Butwal" };
            Console.WriteLine("\nCities array:");
            demo.DisplayArray(cities);
            Console.WriteLine("Number of cities: " + cities.Length);
            Console.WriteLine("First city: " + cities[0]);
            Console.WriteLine("Last city: " + cities[cities.Length - 1]);

            // Modifying elements
            Console.WriteLine("\nModifying scores array:");
            Console.WriteLine("Before: " + scores[2]);
            scores[2] = 95;
            Console.WriteLine("After changing index 2 to 95: " + scores[2]);
            demo.DisplayArray(scores);
        }
        */
    }
}

#endif

