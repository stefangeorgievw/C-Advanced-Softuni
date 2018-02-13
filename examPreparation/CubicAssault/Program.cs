using System;
using System.Collections.Generic;
using System.Linq;

namespace CubicAssault
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, Dictionary<string, long>>();
            var meteorTypes = new string[]
            {
                "Green",
                "Red",
                "Black",
            };

            string input;
            while ((input = Console.ReadLine())!= "Count em all")
            {
                var inputArggs = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                var regionName = inputArggs[0];
                var meteorType = inputArggs[1];
                long count = long.Parse(inputArggs[2]);
                if (!dictionary.ContainsKey(regionName))
                {
                    dictionary[regionName] = new Dictionary<string, long>()
                    {
                        { "Green", 0L },
                        { "Red", 0L },
                        { "Black", 0L }
                    };

                }

                dictionary[regionName][meteorType] += count;
                if (count >= 1_000_000)
                {
                    if (dictionary[regionName][meteorTypes[0]] >= 1_000_000 )
                    {
                        dictionary[regionName][meteorTypes[1]] += dictionary[regionName][meteorTypes[0]] / 1_000_000;
                        dictionary[regionName][meteorTypes[0]] %= 1_000_000;
                    }
                     if (dictionary[regionName][meteorTypes[1]] >= 1_000_000)
                    {
                        dictionary[regionName][meteorTypes[2]] += dictionary[regionName][meteorTypes[1]] / 1_000_000;
                        dictionary[regionName][meteorTypes[1]] %= 1_000_000;
                    }
                }

            }
           
            foreach (var region in dictionary.OrderByDescending(r => r.Value["Black"])
.ThenBy(r => r.Key.Length)
.ThenBy(r => r.Key))
            {
                Console.WriteLine(region.Key);

                foreach (var i in region.Value
                        .OrderByDescending(m => m.Value)
                         .ThenBy(m => m.Key))
                {
                    Console.WriteLine($"-> {i.Key} : {i.Value}");
                }
            }
        }
    }
}
