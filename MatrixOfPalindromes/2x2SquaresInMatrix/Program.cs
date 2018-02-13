using System;
using System.Linq;

namespace _2x2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndColums = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[,] matrix = new char[rowsAndColums[0], rowsAndColums[1]];
            for (int rows = 0; rows < rowsAndColums[0]; rows++)
            {
                var rowValues = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray(); 
                for (int colums = 0; colums < rowsAndColums[1]; colums++) 
                {
                    matrix[rows, colums] = rowValues[colums];
                }
            }

            int count = 0;
            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[rows, col] == matrix[rows, col + 1] &&  matrix[rows, col] == matrix[rows + 1, col + 1] && matrix[rows, col] == matrix[rows + 1, col] && matrix[rows, col + 1] == matrix[rows + 1, col + 1])
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);

        }
    }
}
