using System;
using System.Collections.Generic;
using System.Linq;

namespace JediGalaxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimentions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var matrix = new int[dimentions[0]][];
            var cellValue = 0;

            for (int rows = 0; rows < matrix.Length; rows++)
            {
                matrix[rows] = new int[dimentions[1]];
                for (int cols = 0; cols < matrix[rows].Length; cols++)
                {
                    matrix[rows][cols] = cellValue;
                    cellValue++;
                }
            }

            long result = 0L;

            string input;
            while ((input= Console.ReadLine()) != "Let the Force be with you")
            {
                var ivoPosition = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                var evilPosition = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                EvilMove(matrix, evilPosition);
                result += IvoMove(matrix, ivoPosition);
                
            }

            Console.WriteLine(result);

        }

        private static long IvoMove(int[][] matrix, List<int> ivoPosition)
        {
            var stars = 0L;
            int row = ivoPosition[0];
            int col = ivoPosition[1];
            while (row >= 0 && col < matrix[0].Length)
            {
                if (IsInTheMatrix(matrix,col,row))
                {
                    stars += matrix[row][col];
                }

                row--;
                col++;
            }

            return stars;
        }

        private static void EvilMove(int[][] matrix, List<int> evilPosition)
        {
            var evilRow = evilPosition[0];
            var evilCol = evilPosition[1];

            while (evilRow >= 0 && evilCol >= 0)
            {
                if (IsInTheMatrix(matrix,evilCol,evilRow))
                {
                    matrix[evilRow][evilCol] = 0;
                }
                evilRow--;
                evilCol--;
            }
        }

        private static bool IsInTheMatrix(int[][] matrix, int col, int row)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }
    }
}
