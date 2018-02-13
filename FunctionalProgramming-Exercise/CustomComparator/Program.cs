using System;
using System.Linq;

namespace CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var even = numbers.Where(n => n % 2 == 0).OrderBy(n=>n).ToArray();

            var odd = numbers.Where(n => n % 2 != 0).OrderBy(n=>n).ToArray();

            if (odd.Length == 0)
            {
                Console.Write(string.Join(" ", even));
            }
            else
            {
                foreach (var item in even)
                {
                    Console.Write(item + " ");
                }
            }
            

            Console.Write(string.Join(" ",odd));
        }
    }
}
