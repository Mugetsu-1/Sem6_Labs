#if false
using System;

namespace Unit1CH1._3
{
    class JaggedArrayDemo
    {
        public void DisplayJagged(int[][] jagged)
        {
            Console.WriteLine("Jagged Array:");
            for (int i = 0; i < jagged.Length; i++)
            {
                Console.Write("Row " + i + ": ");
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write(jagged[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        public int SumJagged(int[][] jagged)
        {
            int sum = 0;
            foreach (int[] row in jagged)
            {
                foreach (int num in row)
                    sum += num;
            }
            return sum;
        }
    }

    internal class JaggedArray
    {
        /*
        static void Main(string[] args)
        {
            JaggedArrayDemo demo = new JaggedArrayDemo();

            // Jagged array (array of arrays)
            int[][] jagged1 = new int[3][];
            jagged1[0] = new int[] { 1, 2, 3 };
            jagged1[1] = new int[] { 4, 5, 6, 7 };
            jagged1[2] = new int[] { 8, 9 };

            int[][] jagged2 = new int[][] 
            {
                new int[] { 10, 20 },
                new int[] { 30, 40, 50 },
                new int[] { 60, 70, 80, 90 },
                new int[] { 100 }
            };

            int[][] jagged3 = 
            {
                new int[] { 1 },
                new int[] { 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9, 10 }
            };

            Console.WriteLine("Jagged Array 1:");
            demo.DisplayJagged(jagged1);
            Console.WriteLine("Sum: " + demo.SumJagged(jagged1));
            Console.WriteLine("Number of rows: " + jagged1.Length);
            Console.WriteLine("Row 0 length: " + jagged1[0].Length);
            Console.WriteLine("Row 1 length: " + jagged1[1].Length);
            Console.WriteLine("Row 2 length: " + jagged1[2].Length);

            Console.WriteLine("\nJagged Array 2:");
            demo.DisplayJagged(jagged2);
            Console.WriteLine("Sum: " + demo.SumJagged(jagged2));

            Console.WriteLine("\nJagged Array 3:");
            demo.DisplayJagged(jagged3);

            // Accessing elements
            Console.WriteLine("\nAccessing elements:");
            Console.WriteLine("jagged1[0][1] = " + jagged1[0][1]);
            Console.WriteLine("jagged2[2][3] = " + jagged2[2][3]);
            Console.WriteLine("jagged3[3][2] = " + jagged3[3][2]);

            // Modifying elements
            Console.WriteLine("\nModifying jagged1[1][2] from 6 to 99");
            jagged1[1][2] = 99;
            demo.DisplayJagged(jagged1);
        }
        */
    }
}

#endif

