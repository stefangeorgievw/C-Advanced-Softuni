using System;
using System.IO;

namespace LineNumbers
{
    class Program
    {
        private const string path = "../../Files/";
        static void Main(string[] args)
        {
            Console.WriteLine($"Read file '{path}CSharpAdvanced.txt'");
            Console.WriteLine($"Insert line numbers & write text to '{path}CSharpAdvanced-LineNumbers.txt'");

            using (var reader = new StreamReader($"Files/CSharpAdvanced.txt"))
            {
                using (var writer = new StreamWriter($"Files/CSharpAdvanced-LineNumbers.txt"))
                {
                    int lineNumbers = 0;
                    while (true)
                    {
                        string line = reader.ReadLine();
                        if (line == null) break;

                        writer.WriteLine($"Line {++lineNumbers}: {line}");
                    }
                }
            }
        }
    }
}
