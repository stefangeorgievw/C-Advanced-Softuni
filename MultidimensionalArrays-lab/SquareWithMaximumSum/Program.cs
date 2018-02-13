using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndColums = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None).Select(int.Parse).ToArray();
            int[,] matrix = new int[rowsAndColums[0], rowsAndColums[1]];
            for (int rows = 0; rows < rowsAndColums[0]; rows++)
            {
                var rowValues = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None).Select(int.Parse).ToArray();
                for (int colums = 0; colums < rowsAndColums[1]; colums++)
                {
                    matrix[rows, colums] = rowValues[colums];
                }
            }


            int sum = int.MinValue;
            int rowsIndex = 0;
            int columsIndex = 0;

            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                for (int colums = 0; colums < matrix.GetLength(1) - 1; colums++)
                {
                    var tempSum = matrix[rows, colums] + matrix[rows, colums + 1] +
                        matrix[rows + 1, colums] + matrix[rows + 1, colums + 1];

                    if (tempSum > sum)
                    {
                        sum = tempSum;
                        rowsIndex = rows;
                        columsIndex = colums;
                    }
                }
            }

            Console.WriteLine(matrix[rowsIndex, columsIndex] + " " + matrix[rowsIndex, columsIndex + 1]);
            Console.WriteLine(matrix[rowsIndex + 1, columsIndex] + " " + matrix[rowsIndex + 1, columsIndex + 1]);
            Console.WriteLine(sum);
        }


    }
}
