using System;
using System.Collections.Generic;
using System.Linq;

namespace CubicArtillery
{
    class Program
    {
        static void Main(string[] args)
        {
            var bunkers = new Queue<char>();
            var currentBunker = new Queue<int>();

            int maxCapacity = int.Parse(Console.ReadLine());
            var leftCapacity = maxCapacity;
            string input;

            while ((input = Console.ReadLine()) != "Bunker Revision")
            {
                var inputArggs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                foreach (var item in inputArggs)
                {
                    int weapon ;
                    bool isDigit = int.TryParse(item, out weapon);
                    if (!isDigit)
                    {
                        bunkers.Enqueue(char.Parse(item));
                    }
                    else
                    {
                        bool isSaved = false;
                        int weapon1 = int.Parse(item);
                        while (bunkers.Count > 1)
                        {
                            if (leftCapacity>= weapon1 )
                            {
                                currentBunker.Enqueue(weapon1);
                                isSaved = true;
                                leftCapacity -= weapon1;
                                break;
                            }
                            else
                            {
                                var removedBunker = bunkers.Dequeue();
                                if (currentBunker.Count == 0)
                                {
                                    Console.WriteLine($"{removedBunker} -> Empty");
                                }
                                else
                                {
                                    Console.WriteLine($"{removedBunker} -> {string.Join(", ", currentBunker)}");
                                }
                                currentBunker.Clear();
                                leftCapacity = maxCapacity;
                               
  
                            }
                        }

                        if (!isSaved)
                        {
                            if (weapon1 <= maxCapacity)
                            {
                                while (leftCapacity < weapon1)
                                {
                                    leftCapacity +=currentBunker.Dequeue();
                                }
                                currentBunker.Enqueue(weapon1);
                                leftCapacity -= weapon1;
                            
                            }
                        }
                    }
                }
            }

        }
    }
}
