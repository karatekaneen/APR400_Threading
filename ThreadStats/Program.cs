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

            Printer.StartPrint();


            Console.ReadKey();

        }


    }
}
