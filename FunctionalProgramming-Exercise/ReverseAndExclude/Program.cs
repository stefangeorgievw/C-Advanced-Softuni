﻿using System;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
              .Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse);

            var divisor = int.Parse(Console.ReadLine());
            Func<int, bool> filter = n => n % divisor != 0;

            var remainingNumbers = numbers.Reverse().Where(filter);

            Console.WriteLine(string.Join(" ", remainingNumbers));
        }
    }
}
