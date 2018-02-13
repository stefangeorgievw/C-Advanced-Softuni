using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\[[^\s+]+?<([0-9]+)REGEH([0-9]+)>[^\s+]+?\])";

            var input = Console.ReadLine();

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            int index = 0;
            List<char> result = new List<char>();
            foreach (Match match in matches)
            {
                int firstIndex = int.Parse(match.Groups[2].Value);
                int secondIndex = int.Parse(match.Groups[3].Value);

                index += firstIndex;
                
                if (index >= input.Length)
                {
                    result.Add(input[(index % input.Length) + 1]);
                }
                else
                {
                    result.Add(input[index]);
                }


                index += secondIndex; 
                if (index >= input.Length)
                {
                    result.Add(input[(index % input.Length) + 1]);
                }
                else
                {
                    result.Add(input[index]);
                    
                }

            }

            Console.WriteLine(String.Join("",result));
           
        }
    }
}
