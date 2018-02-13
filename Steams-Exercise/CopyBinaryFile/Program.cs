using System;
using System.IO;

namespace CopyBinaryFile
{
    class Program

    {
        private const string path = "../../Files/";
        static void Main(string[] args)
        {
            Console.WriteLine($"Copy file '{path}copyMe.png'");
            Console.WriteLine($"To file '{path}copied.png'");

            var sourceFilePath = $"Files/copyMe.png";
            var copyFilePath = $"Files/copied.png";

            using (var sourceFile = new FileStream(sourceFilePath, FileMode.Open))
            {
                using (var copyFile = new FileStream(copyFilePath, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        int readBytes = sourceFile.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0) break;

                        copyFile.Write(buffer, 0, readBytes);
                        //Console.WriteLine($"{(double)sourceFile.Position / sourceFile.Length:P}");
                    }
                }
            }
        }
    }
}
