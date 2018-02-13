using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var result = new List<int>();
            int count = 0;
            var deviders = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int i = 1; i <= n; i++)
            {
                foreach (var item in deviders)
                {
                    if (i % item == 0)
                    {
                        count++;
                    }
                }
                if (count == deviders.Length)
                {
                    result.Add(i);
                }
                count = 0;
            }

            Console.WriteLine(string.Join(" ",result));

        }
    }
}
