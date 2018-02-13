using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseNumbersWithStack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>();

            Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(strNumber => numbers.Push(int.Parse(strNumber)));

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
