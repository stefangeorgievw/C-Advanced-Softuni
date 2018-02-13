using System;
using System.Linq;

namespace CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
               .Where(s => char.IsUpper(s[0]));

            foreach (var num in numbers)
            {
                Console.WriteLine(num);
            }
                

        }
    }
}
