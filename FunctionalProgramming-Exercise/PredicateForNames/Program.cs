using System;
using System.Linq;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var remaining = names.Where(n => n.Length <= count).ToArray();

            foreach (var item in remaining)
            {
                Console.WriteLine(item);
            }
        }
    }
}
