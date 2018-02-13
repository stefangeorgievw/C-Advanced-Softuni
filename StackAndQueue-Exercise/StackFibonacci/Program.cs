using System;
using System.Collections.Generic;

namespace StackFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = int.Parse(Console.ReadLine());

            var stack = new Stack<long>();
           
            stack.Push(0);
            stack.Push(1);
            for (long i = 0; i <= n - 2; i++)
            {
                long a = stack.Pop();
                long b = stack.Peek();
                long c = a + b;
                stack.Push(a);
                stack.Push(c);
                
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
