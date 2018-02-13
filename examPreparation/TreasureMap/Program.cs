using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TreasureMap
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"((?<hash>#)|!)[^#!]*?(?<![A-Za-z0-9])(?<streetName>[a-zA-Z]{4})(?![A-Za-z0-9])[^#!]*(?<!\d)(?<streetNumber>\d{3})-(?<pass>\d{4}|\d{6})(?!\d)[^#|!]*(?(hash)!|#)";

            Regex regex = new Regex(pattern);
            int n = int.Parse(Console.ReadLine());
            List<string> instructions = new List<string>();
            for (int i = 0; i < n; i++)
            {
                instructions.Add(Console.ReadLine());
                  
            }

            for (int i = 0; i < instructions.Count; i++)
            {
                MatchCollection matches = regex.Matches(instructions[i]);

                if (matches.Count == 0)
                {
                    continue;
                }
                
                if (matches.Count % 2 == 0)
                {
                    int count = 0;
                    foreach (Match match in matches)
                    {
                        count++;
                        if (count %2 == 0)
                        {
                            Console.Write($"Go to str. {match.Groups["streetName"].Value} {match.Groups["streetNumber"].Value}.");
                            Console.Write($" Secret pass: {match.Groups["pass"].Value}.");
                            Console.WriteLine();
                        }
                    }
                }
                else
                {
                    int count = 0;
                    foreach (Match match in matches)
                    {
                        count++;
                        if (count % 2 == 1)
                        {
                            Console.Write($"Go to str. {match.Groups["streetName"].Value} {match.Groups["streetNumber"].Value}.");
                            Console.Write($" Secret pass: {match.Groups["pass"].Value}.");
                            Console.WriteLine();
                        }
                    }
                }


            }
        }
    }
}
