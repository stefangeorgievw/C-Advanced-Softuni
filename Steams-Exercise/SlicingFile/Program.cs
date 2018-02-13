﻿using System;
using System.Collections.Generic;
using System.IO;

namespace SlicingFile
{
    class Program
    {
        private const string path = "../../Files/";
        private static List<string> listFileParts = new List<string>();
        static void Main(string[] args)
        {
            Console.Write("Enter number of parts [int]: ");
            int partsCount = int.Parse(Console.ReadLine());

            SliceFileIntoParts(partsCount);
            AssembleFileFromParts();
        }
        private static void AssembleFileFromParts()
        {
            Console.WriteLine($"Assembling file parts into '{path}assembledImage.jpg'");

            var buffer = new byte[4096];
            using (var assembledImage = new FileStream($"Files/assembledImage.jpg", FileMode.Create))
            {
                for (int i = 0; i < listFileParts.Count; i++)
                {
                    using (var reader = new FileStream(listFileParts[i], FileMode.Open))
                    {
                        while (true)
                        {
                            int readBytes = reader.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0) break;

                            assembledImage.Write(buffer, 0, readBytes);
                        }
                    }
                }
            }
        }

        private static void SliceFileIntoParts(int partsCount)
        {
            Console.WriteLine($"Slicing file '{path}copyMe.png' into {partsCount} parts");

            var buffer = new byte[4096];
            using (var sourceFile = new FileStream($"Files/copyMe.png", FileMode.Open))
            {
                var partSize = Math.Ceiling((double)sourceFile.Length / partsCount);
                for (int i = 0; i < partsCount; i++)
                {
                    var filePartName = $"Files/Part-{i}.jpg";
                    listFileParts.Add(filePartName);

                    using (var destinationFile = new FileStream(filePartName, FileMode.Create))
                    {
                        int totalBytes = 0;
                        while (totalBytes < partSize)
                        {
                            int readBytes = sourceFile.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0) break;

                            destinationFile.Write(buffer, 0, readBytes);
                            totalBytes += readBytes;
                        }
                    }
                }
            }
        }
    }
}

