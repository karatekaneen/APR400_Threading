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

            PrintThreadInfo(); // Call info function from main thread

            Console.ReadKey();

        }

        public static void PrintThreadInfo()
        {
            Console.WriteLine($"Name: {Thread.CurrentThread.Name} \n Priority: {Thread.CurrentThread.Priority} \n State: {Thread.CurrentThread.ThreadState} \n Is background thread: {Thread.CurrentThread.IsBackground}");
        }
    }
}
