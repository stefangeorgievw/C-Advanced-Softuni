using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimentions[0];
            int cols = dimentions[1];

            int[,] matrix = new int[dimentions[0], dimentions[1]];

            var input = Console.ReadLine();
            HashSet<string> occupied = new HashSet<string>();
            while (input != "stop")
            {
                var inputArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int entryRow = inputArgs[0];
                int desiredRow = inputArgs[1];
                int desiredCol = inputArgs[2];

                string cordinates = String.Format($"{desiredRow}|{desiredCol}");

                if (!occupied.Contains(cordinates))
                {
                    occupied.Add(cordinates);
                    var passedDistance = Math.Abs(entryRow - desiredRow) + desiredCol + 1;
                    Console.WriteLine(passedDistance);
                }
                else
                {
                    var col = 0;
                    bool found = false;
                    for (int i = 1; i < Math.Max(desiredCol - 1, cols - desiredCol); i++)
                    {
                        string left = string.Format($"{desiredRow}|{desiredCol - i}");
                        string right = string.Format($"{desiredRow}|{desiredCol + i}");

                        if (!occupied.Contains(left) && desiredCol - i > 0)
                        {
                            occupied.Add(left);
                            col = desiredCol - i;

                            CalculateAndPrintDistance(entryRow, desiredRow, col);
                            found = true;
                            break;

                        }

                        if (!occupied.Contains(right) && desiredCol + i < cols)
                        {
                            occupied.Add(right);
                            col = desiredCol + i;
                            CalculateAndPrintDistance(entryRow, desiredRow, col);
                            found = true;
                            break;
                        }
                      

                    }

                    if (found == false)
                    {
                        Console.WriteLine($"Row {desiredRow} full");
                        break;
                    }

                }
                input = Console.ReadLine();
            }
        }

        private static void CalculateAndPrintDistance(int entryRow, int desiredRow, int col)
        {
            var passedDistance = Math.Abs(entryRow - desiredRow) + col + 1;
            Console.WriteLine(passedDistance);
        }
    }
}
