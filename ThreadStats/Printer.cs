using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadStats
{
    class Printer
    {
        public static void StartPrint()
        {
            int numberOfThreads = 0;
            while (numberOfThreads != 1 && numberOfThreads != 2)
            {
                Console.WriteLine("Do you want to run PrintNumbers in 1 or 2 strings?");
                int userInput = int.Parse(Console.ReadLine());
                if (userInput == 1 || userInput == 2) numberOfThreads = userInput;
            }

            if (numberOfThreads == 1)
            {
                PrintNumbers(); // Only use current thread
            } else
            {
                Thread worker = new Thread(PrintNumbers); // Create a new thread and delegate a method to run
                worker.Name = "Worker"; // Give it a name
                worker.IsBackground = true; // Make it a background thread.
                worker.Start(); // Start the worker thread and allow the function to run in a separate thread

                PrintNumbers(); // Run it in the current thread too.
            }
        }

        public static void PrintNumbers()
        {
            // Show thread summary
            PrintThreadInfo(); 

            for (int i = 1; i < 11; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} - {i}"); // Print thread name and int i
                Thread.Sleep(1999); // Sleep for approx. 2 seconds.
            }
        }

        public static void PrintThreadInfo()
        {
            Console.WriteLine($"Name: {Thread.CurrentThread.Name} \n Priority: {Thread.CurrentThread.Priority} \n State: {Thread.CurrentThread.ThreadState} \n Is background thread: {Thread.CurrentThread.IsBackground}");
        }
    }
}
