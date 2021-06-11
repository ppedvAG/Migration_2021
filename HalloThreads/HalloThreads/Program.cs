using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HalloThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hallo Threads");

            //Parallel.Invoke(Zähle, Zähle, Zähle);

            Parallel.For(0, 1000000, i => Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} -> {i}"));



            Console.WriteLine("Ende");
            Console.ReadLine();
        }

        private static void Zähle()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} -> {i}");
            }
        }
    }
}
