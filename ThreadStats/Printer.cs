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
        static bool done;
        static readonly object locker = new object();


        public static void PrintNumbers(object data)
        {
            Random random = new Random();
            // Show thread summary
            PrintThreadInfo(); 

            lock (locker)
            {
                if (!done)
                {
                    for (int i = 1; i < 11; i++)
                    {
                        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - {i}"); // Print thread name and int i
                        int sleepTime = random.Next(50, 1000);
                        Thread.Sleep(sleepTime); // Sleep for random amount of time between 50 and 1000ms.
                    }
                    done = true;
                }
            }
        }

        public static void PrintThreadInfo()
        {
            Console.WriteLine($"Name: {Thread.CurrentThread.Name} \n Priority: {Thread.CurrentThread.Priority} \n State: {Thread.CurrentThread.ThreadState} \n Is background thread: {Thread.CurrentThread.IsBackground}");
        }
    }
}