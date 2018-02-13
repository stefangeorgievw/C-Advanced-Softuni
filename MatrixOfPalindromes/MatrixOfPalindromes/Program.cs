using System;
using System.Linq;

namespace MatrixOfPalindromes
{
    class Program
    {
       

        static void Main(string[] args)
        {
            int[] rowsAndColums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[,] matrix = new int[rowsAndColums[0],rowsAndColums[1]];
            char a = 'a';
            char b = 'a';

            for (int rows = 0; rows < rowsAndColums[0]; rows++)
            {
                for (int colums = 0; colums < rowsAndColums[1]; colums++)
                {
                    Console.Write(a);
                    Console.Write(b);
                    Console.Write(a);
                    Console.Write(" ");
                    b++;
                }
                Console.WriteLine();
                a++;
                b = a;
            }
        }
    }
}
