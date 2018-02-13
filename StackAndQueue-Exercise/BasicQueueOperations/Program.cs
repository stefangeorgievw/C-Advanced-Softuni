using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int N = input[0];
            int S = input[1];
            int X = input[2];
            
            var elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var queue = new Queue<int>(elements);
            for (int i = 0; i < S; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(X))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine(0);
                    return;
                }
                Console.WriteLine(queue.Min());
            }
            
        }
    }
}
