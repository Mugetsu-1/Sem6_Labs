#if false
using System;

namespace IndexerApp
{
    class Matrix
    {
        private int[,] data;
        public int Rows { get; private set; }
        public int Cols { get; private set; }

        public Matrix(int rows, int cols) { Rows = rows; Cols = cols; data = new int[rows, cols]; }

        public int this[int row, int col]
        {
            get => (row >= 0 && row < Rows && col >= 0 && col < Cols) ? data[row, col] : throw new IndexOutOfRangeException("Invalid index");
            set { if (row >= 0 && row < Rows && col >= 0 && col < Cols) data[row, col] = value; else throw new IndexOutOfRangeException("Invalid index"); }
        }

        public void Display()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++) Console.Write($"{data[i, j],5}");
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        /*
        static void Main(string[] args)
        {
            Matrix mat = new Matrix(3, 3);
            int val = 1;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    mat[i, j] = val++;

            mat.Display();
            Console.WriteLine($"mat[1, 1] = {mat[1, 1]}");
        }
        */
    }
}

#endif

