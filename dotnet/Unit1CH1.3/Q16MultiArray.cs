#if false
using System;

namespace Unit1CH1._3
{
    class MultiArrayDemo
    {
        public void Display2D(int[,] matrix)
        {
            Console.WriteLine("2D Array:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void Display3D(int[,,] cube)
        {
            Console.WriteLine("3D Array:");
            for (int i = 0; i < cube.GetLength(0); i++)
            {
                for (int j = 0; j < cube.GetLength(1); j++)
                {
                    for (int k = 0; k < cube.GetLength(2); k++)
                    {
                        Console.Write(cube[i, j, k] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        public int Sum2D(int[,] matrix)
        {
            int sum = 0;
            foreach (int num in matrix)
                sum += num;
            return sum;
        }
    }

    internal class MultiArray
    {
        /*
        static void Main(string[] args)
        {
            MultiArrayDemo demo = new MultiArrayDemo();

            // 2D Array (3 rows, 4 columns)
            int[,] matrix1 = new int[3, 4] 
            { 
                { 1, 2, 3, 4 }, 
                { 5, 6, 7, 8 }, 
                { 9, 10, 11, 12 } 
            };

            int[,] matrix2 = { { 10, 20 }, { 30, 40 }, { 50, 60 } };

            Console.WriteLine("Matrix 1:");
            demo.Display2D(matrix1);
            Console.WriteLine("Sum: " + demo.Sum2D(matrix1));
            Console.WriteLine("Rows: " + matrix1.GetLength(0));
            Console.WriteLine("Columns: " + matrix1.GetLength(1));

            Console.WriteLine("\nMatrix 2:");
            demo.Display2D(matrix2);

            // Accessing elements
            Console.WriteLine("\nAccessing elements:");
            Console.WriteLine("matrix1[0,2] = " + matrix1[0, 2]);
            Console.WriteLine("matrix2[2,1] = " + matrix2[2, 1]);

            // Modifying elements
            Console.WriteLine("\nModifying matrix1[1,1] from 6 to 100");
            matrix1[1, 1] = 100;
            demo.Display2D(matrix1);

            // 3D Array
            int[,,] cube = new int[2, 2, 3] 
            { 
                { { 1, 2, 3 }, { 4, 5, 6 } }, 
                { { 7, 8, 9 }, { 10, 11, 12 } } 
            };

            Console.WriteLine("\n3D Array:");
            demo.Display3D(cube);
            Console.WriteLine("Total elements: " + cube.Length);
        }
        */
    }
}

#endif

