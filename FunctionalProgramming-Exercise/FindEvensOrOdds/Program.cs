using System;
using System.Linq;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string oddOrEven = Console.ReadLine();
            for (int i = input[0]; i <= input[1]; i++)
            {
                if (oddOrEven == "odd")
                {
                    if (i % 2 == 1 || i % 2 == -1)
                    {
                        Console.Write(i + " ");
                    }
                }


                if (oddOrEven == "even")
                {
                    if (i % 2 == 0)
                    {
                        Console.Write(i + " ");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
