using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadStats
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * This is my lab about threading for the course APR400, Advanced C#. 
             * Each commit finishes the task mentioned in the commit message.
             */

            Thread.CurrentThread.Name = "MainThread"; // Set main name

            Printer.PrintThreadInfo(); // Call info function from main thread

            StartPrint();


            Console.ReadKey();

        }

        public static void StartPrint()
        {
            int numberOfThreads = 0;
            while (numberOfThreads != 1 && numberOfThreads != 2)
            {
                Console.WriteLine("Do you want to run PrintNumbers in 1 or if you want 10 enter ''2'' strings?");
                int userInput = int.Parse(Console.ReadLine());
                if (userInput == 1 || userInput == 2) numberOfThreads = userInput;
            }

            if (numberOfThreads == 1)
            {
                Printer.PrintNumbers(); // Only use current thread
            }
            else
            {
                Thread[] threads = new Thread[10];
                for (int i = 0; i < threads.Length; i++)
                {
                    threads[i] = new Thread(Printer.PrintNumbers);
                    threads[i].Name = $"Worker_{i}"; // Give it an unique name
                    threads[i].IsBackground = true; // Make it a background thread.
                    threads[i].Start(); // Start the worker thread and allow the function to run in a separate thread
                }
                

                Printer.PrintNumbers(); // Run it in the current thread too.
            }
        }

    }
}
