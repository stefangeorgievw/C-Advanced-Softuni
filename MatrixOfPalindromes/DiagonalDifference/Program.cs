using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int rows = 0; rows < n; rows++)
            {
                var rowValues = Console.ReadLine()
                    .Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int colums = 0; colums < n; colums++)
                {
                    matrix[rows, colums] = rowValues[colums];
                }
            }

            int temp = 0;
            int leftDiagonal = matrix[0, 0];
            for (int i = 0; i < n - 1; i++)
            {

                leftDiagonal += matrix[temp + 1, temp + 1];

                temp++;
            }


            int rightDiagonal = matrix[0, n - 1];
            int temp2 = n - 1;
            int temp3 = 0;
            for (int i = 0; i < n - 1; i++)
            {
                rightDiagonal += matrix[temp3 + 1, temp2 - 1];
                temp2--;
                temp3++;
            }
            int difference = leftDiagonal - rightDiagonal;
            Console.WriteLine(Math.Abs(difference));
        }
    }
}
