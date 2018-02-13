using System;
using System.Linq;

namespace CryptoMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
               .Split(new[] { ", " },
                   StringSplitOptions.RemoveEmptyEntries)
               .Select(long.Parse)
               .ToList();

            long maxLenght = 0;

            for (int steps = 0; steps < nums.Count; steps++)
            {
                for (int current = 0; current < nums.Count; current++)
                {
                    long currentLenght = 1;

                    var currentElementIndex = current;
                    var nextElementIndex = (currentElementIndex + steps) % nums.Count;

                    while (nums[nextElementIndex] > nums[currentElementIndex])
                    {
                        currentLenght++;

                        currentElementIndex = nextElementIndex;
                        nextElementIndex= (currentElementIndex + steps) % nums.Count;
                    }

                    if (currentLenght > maxLenght)
                    {
                        maxLenght = currentLenght;
                    }
                }
            }

            Console.WriteLine(maxLenght);
        }
    }
}
