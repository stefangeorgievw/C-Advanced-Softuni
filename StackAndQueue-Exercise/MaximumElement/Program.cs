using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            var maxStack = new Stack<int>();
            int maxElement = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                int command = input[0];


                switch (command)
                {
                    case 1:
                        int number = input[1];
                        if (maxElement < number)
                        {
                            maxElement = number;
                            maxStack.Push(maxElement);
                        }
                        stack.Push(number);
                        break;

                    case 2:
                        if (stack.Peek() == maxStack.Peek() && maxStack.Count > 0)
                        {
                            maxStack.Pop();
                            if (maxStack.Count > 0)
                            {
                                maxElement = maxStack.Peek();
                            }
                            else
                            {
                                maxElement = int.MinValue;
                            }
                        }
                        stack.Pop();
                        break;
                    case 3:
                        Console.WriteLine(maxStack.Peek());
                        break;
                }
            }
        }
    }
}
