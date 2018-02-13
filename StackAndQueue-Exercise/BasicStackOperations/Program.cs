using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
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
            var stack = new Stack<int>();
            var elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            

            for (int i = 0; i < N; i++)
            {
                stack.Push(elements[i]);
            }

            for (int i = 0; i < S; i++)
            {
                stack.Pop();
            }
            if (stack.Count > 0)
            {
                if (stack.Contains(X))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(stack.Min());

                }
            }
            else
            {
                Console.WriteLine(0);
            }
           



        }
    }
}
