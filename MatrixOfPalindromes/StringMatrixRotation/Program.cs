using System;
using System.Collections.Generic;
using System.Linq;

namespace StringMatrixRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rotation = Console.ReadLine().Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int degrees = int.Parse(rotation[1]);
            List<string> input = new List<string>();
            string word = Console.ReadLine();
            int longestWord = 0;
            while (word != "END")
            {
                input.Add(word);
                if (word.Length > longestWord)
                {
                    longestWord = word.Length;
                }


                word = Console.ReadLine();
            }

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i].Length < longestWord)
                {
                    input[i] = input[i] + new string(' ', longestWord - input[i].Length);
                }
            }

            if (degrees == 180 || degrees % 360 == 180)
            {
                for (int i = input.Count - 1; i >= 0; i--)
                {
                    for (int j = input[i].Length - 1; j >= 0 ; j--)
                    {
                        Console.Write(input[i][j]); 
                    }
                    Console.WriteLine();
                }
            }

            if (degrees == 0 || degrees % 360 == 0)
            {
                for (int i = 0; i < input.Count; i++)
                {
                    for (int j = 0; j < input[i].Length; j++)
                    {
                        Console.Write(input[i][j]);
                    }
                    Console.WriteLine();
                }
            }

            char[,] rotate90 = new char[longestWord, input.Count];

            for (int row = 0; row < longestWord; row++)
            {
                for (int col = 0; col < input.Count; col++)
                {
                    rotate90[row, col] = input[col][row];
                }
            }


            if (degrees == 90 || degrees % 360 == 90)
            {
                for (int i = 0; i < rotate90.GetLength(0); i++)
                {
                    for (int j = rotate90.GetLength(1) - 1; j >= 0; j--)
                    {
                        Console.Write(rotate90[i,j]);
                    }
                    Console.WriteLine();
                }
            }

            if (degrees == 270 || degrees % 360 == 270)
            {
                for (int i = rotate90.GetLength(0) - 1; i >= 0; i--)
                {
                    for (int j = 0; j < rotate90.GetLength(1); j++)
                    {
                        Console.Write(rotate90[i, j]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
