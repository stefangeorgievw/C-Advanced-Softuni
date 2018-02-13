using System;
using System.Linq;

namespace AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
               .Select(double.Parse  )
               .Select(p => p * 1.2)
               .ToList();

            foreach (var num in numbers)
            {
                Console.WriteLine($"{num:f2}");
            }
        }
    }
}
