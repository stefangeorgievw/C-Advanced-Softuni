using System;
using System.Linq;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndColums = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[rowsAndColums[0], rowsAndColums[1]];
            for (int rows = 0; rows < rowsAndColums[0]; rows++)
            {
                var rowValues = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int colums = 0; colums < rowsAndColums[1]; colums++)
                {
                    matrix[rows, colums] = rowValues[colums];
                }
            }

            int sum = int.MinValue;
            int rowIndex = 0;
            int columIndex = 0;


            for (int rows = 0; rows < matrix.GetLength(0) - 2; rows++)
            {
                for (int colums = 0; colums < matrix.GetLength(1) - 2; colums++)
                {
                    var tempSum = matrix[rows, colums] + matrix[rows, colums + 1] + matrix[rows, colums + 2]+
                        matrix[rows + 1, colums] + matrix[rows + 1, colums + 1] + matrix[rows + 1, colums + 2] +
                        matrix[rows + 2, colums] + matrix[rows + 2, colums + 1] + matrix[rows + 2, colums + 2];


                    if (tempSum > sum)
                    {
                        sum = tempSum;
                        rowIndex = rows;
                        columIndex = colums;
                    }
                }
            }
            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine(matrix[rowIndex, columIndex] + " " + matrix[rowIndex, columIndex + 1] + " " + matrix[rowIndex, columIndex + 2]);
            Console.WriteLine(matrix[rowIndex + 1, columIndex] + " " + matrix[rowIndex + 1, columIndex + 1] + " " + matrix[rowIndex + 1, columIndex + 2]);
            Console.WriteLine(matrix[rowIndex + 2, columIndex] + " " + matrix[rowIndex + 2, columIndex + 1] + " " + matrix[rowIndex + 2, columIndex + 2]);
            
            

        }
    }
}
