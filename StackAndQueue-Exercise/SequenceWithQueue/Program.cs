using System;
using System.Collections.Generic;

namespace SequenceWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var seqTemp = new Queue<long>();
            var seqPrint = new Queue<long>();

            long N = long.Parse(Console.ReadLine());
            seqTemp.Enqueue(N);
            while (seqPrint.Count <= 49)
            {
                seqTemp.Enqueue(seqTemp.Peek() + 1);
                seqTemp.Enqueue(2 * seqTemp.Peek() + 1);
                seqTemp.Enqueue(seqTemp.Peek() + 2);
                seqPrint.Enqueue(seqTemp.Dequeue());
            }
            while (seqPrint.Count > 0)
            {
                Console.Write(seqPrint.Dequeue() + " ");
            }
            Console.WriteLine();
        }
    }
}
