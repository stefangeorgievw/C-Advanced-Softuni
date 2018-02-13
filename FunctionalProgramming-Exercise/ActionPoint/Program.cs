using System;

namespace ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Action<string> print = message => Console.WriteLine(message);

            foreach (var name in input)
            {
                print(name);
            }

            
        }
    }
}
