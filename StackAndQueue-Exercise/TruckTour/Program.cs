using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var queue = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                var pump = Console.ReadLine().Split(' ')
                    .Select(int.Parse).ToArray();

                queue.Enqueue(pump);
            }

            for (int currentStart = 0; currentStart < n - 1; currentStart++)
            {
                int fuel = 0;
                bool IsSolution = true;

                for (int pumpsPassed = 0; pumpsPassed < n; pumpsPassed++)
                {
                    var currentPump = queue.Dequeue();
                    int pumpFuel = currentPump[0];
                    int nextPumpFuel = currentPump[1];
                    queue.Enqueue(currentPump);
                    fuel += pumpFuel - nextPumpFuel;

                    if (fuel < 0)
                    {
                        currentStart += pumpsPassed;
                        IsSolution = false;
                        break;
                    }
                }
                if (IsSolution == true)
                {
                    Console.WriteLine(currentStart);
                    Environment.Exit(0);
                }
            }
        }
    }
}
