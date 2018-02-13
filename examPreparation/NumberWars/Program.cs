using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NumberWars
{
    class Program
    {
        static void Main(string[] args)
        {
            

            var firstQueue = new Queue<string>(Console.ReadLine().Split());
            var secondQueue = new Queue<string>(Console.ReadLine().Split());

            int countOfTurns = 0;
            var list1 = new List<string>();
            var list2 = new List<string>();

            while (firstQueue.Count > 0 && secondQueue.Count > 0 && countOfTurns < 1_000_000)
            {
                var firstCurrentCard = firstQueue.Dequeue();
                var firstPower = int.Parse(firstCurrentCard.Substring(0, firstCurrentCard.Length - 1));

                var secondCurrentCard = secondQueue.Dequeue();
                var secondPower = int.Parse(secondCurrentCard.Substring(0, secondCurrentCard.Length - 1));

                if (firstPower > secondPower)
                {
                    firstQueue.Enqueue(firstCurrentCard);
                    firstQueue.Enqueue(secondCurrentCard);

                }
               else if (secondPower > firstPower)
                { 
                    secondQueue.Enqueue(secondCurrentCard);
                    secondQueue.Enqueue(firstCurrentCard);

                }
                if (secondPower == firstPower)
                {
                    list1.Add(secondCurrentCard);
                    list1.Add(firstCurrentCard);
                    bool HasAWinner = false;
                    while (HasAWinner == false)
                    {
                        if (firstQueue.Count < 3 || secondQueue.Count < 3)
                        {
                            if (firstQueue.Count < secondQueue.Count)
                            {
                                Console.WriteLine($"First player wins after {countOfTurns} turns");
                                Environment.Exit(0);
                            }
                            else if(firstQueue.Count > secondQueue.Count)
                            {
                                Console.WriteLine($"Second player wins after {countOfTurns} turns");
                                Environment.Exit(0);
                            }
                            else
                            {
                                countOfTurns++;
                                Console.WriteLine($"Draw after {countOfTurns} turns");
                                Environment.Exit(0);
                            }
                        }
                        int sum1 = 0;
                        int sum2 = 0;
                        for (int i = 0; i < 3; i++)
                        {
                            var currentString1 = firstQueue.Dequeue();
                            var ch1 = currentString1.Last();
                            list1.Add(currentString1);
                            
                            sum1 += ch1;

                            var currentString2 = secondQueue.Dequeue();
                            var ch2 = currentString2.Last();
                            list1.Add(currentString2);
                           
                            sum2 += ch2;
                        }

                        if (sum1 > sum2)
                        {
                            foreach (var item in list1.OrderByDescending(n=>n))
                            {
                                firstQueue.Enqueue(item);
                                HasAWinner = true;
                            }
                        }
                        else if (sum1 < sum2)
                        {
                            foreach (var item in list1.OrderByDescending(n => n))
                            {
                                secondQueue.Enqueue(item);
                                HasAWinner = true;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                countOfTurns++;
            }

            if (countOfTurns == 1_000_000)
            {
                if (firstQueue.Count > secondQueue.Count)
                {
                    Console.WriteLine($"First player wins after {countOfTurns} turns");
                }

                else if (firstQueue.Count < secondQueue.Count)
                {
                    Console.WriteLine($"Second player wins after {countOfTurns} turns");
                }
                else
                {
                    Console.WriteLine($"Draw after {countOfTurns} turns");
                }
            }

            else
            {
                if (firstQueue.Count > 0)
                {
                    Console.WriteLine($"First player wins after {countOfTurns} turns");
                }
                else if (secondQueue.Count > 0)
                {
                    Console.WriteLine($"Second player wins after {countOfTurns} turns");
                }
                else
                {
                    Console.WriteLine($"Draw after {countOfTurns} turns");
                }
            }

        }
    }
}
