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
                Console.WriteLine("Do you want to run PrintNumbers in 1 or if you want 10 enter '2' strings?");
                int userInput = int.Parse(Console.ReadLine());
                if (userInput == 1 || userInput == 2) numberOfThreads = userInput;
            }

            if (numberOfThreads == 1)
            {
               //Printer.PrintNumbers(); // Disabled while PrintNumbers is built for ThreadPool
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    ThreadPool.QueueUserWorkItem(Printer.PrintNumbers, i);
                }
                
            }
        }

    }
}