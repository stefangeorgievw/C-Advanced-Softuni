﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPreparation
{
    class JediMeditation
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var master = new List<string>();
            var knight = new List<string>();
            var padawan = new List<string>();
            var toshkoSlav = new List<string>();
            var yoda = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < input.Length; j++)
                {
                    var currentJedi = input[j].ToLower();

                    if (currentJedi.StartsWith("m"))
                    {
                        master.Add(currentJedi);
                    }
                    if (currentJedi.StartsWith("k"))
                    {
                        knight.Add(currentJedi);
                    }
                    if (currentJedi.StartsWith("p"))
                    {
                        padawan.Add(currentJedi);
                    }
                    if (currentJedi.StartsWith("t") || currentJedi.StartsWith("s"))
                    {
                        toshkoSlav.Add(currentJedi);
                    }
                  
                    if (currentJedi.StartsWith("y"))
                    {
                        yoda.Add(currentJedi);
                    }

                }

            }

            if (!yoda.Any())
            {
                Console.WriteLine(string.Join(" ", toshkoSlav) + " " + string.Join(" ", master) + " " + string.Join(" ", knight) +
                  " " + string.Join(" ", padawan));
            }
            else
            {
                Console.WriteLine(string.Join(" ", master) + " " + string.Join(" ", knight) + " " + string.Join(" ", toshkoSlav) + " " +
                    string.Join(" ", padawan));
            }
        }
    }
}