using System;
using System.IO;
using System.Text;


namespace OddLines
{
    class Program
    {
        private const string path = "../../Files/";

        static void Main(string[] args)
        {
            Console.WriteLine($"Print odd lines from file '{path}text.txt'\n");

            using (var reader = new StreamReader($"Files/text.txt"))
            {
                int lineNumber = 0;

                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null) break;

                    if (lineNumber % 2 != 0)
                    {
                        Console.WriteLine($"Line {lineNumber}: {line}");
                    }
                    lineNumber++;
                }
            }
        }
    }
}
