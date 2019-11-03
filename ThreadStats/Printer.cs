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

        static readonly object _object = new object(); // object to use in the Monitor

        public static void PrintNumbers(object data)
        {
            Random random = new Random();
            // Show thread summary
            PrintThreadInfo();
            for (int i = 1; i < 11; i++)
            {
                try
                {
                    Monitor.Enter(_object); // Enter the critical part

                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - {i}"); // Print thread name and int i
                }
                finally
                {
                    Monitor.Exit(_object); // Exit the critical part
                }
                int sleepTime = random.Next(50, 1000);
                Thread.Sleep(sleepTime); // Sleep for random amount of time between 50 and 1000ms.
            }
        }
            
        

        public static void PrintThreadInfo()
        {
            Console.WriteLine($"Name: {Thread.CurrentThread.Name} \n Priority: {Thread.CurrentThread.Priority} \n State: {Thread.CurrentThread.ThreadState} \n Is background thread: {Thread.CurrentThread.IsBackground}");
        }
    }
}