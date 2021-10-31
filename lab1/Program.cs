using System;
using System.Threading;

using System;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskQueue taskQueue = new TaskQueue(10);

            for (int i = 0; i < 20; i++)
            {
                taskQueue.EnqueueTask(Test);
            }
        }

        static void Test()
        {
            Console.WriteLine("TestTask in thread #" + Thread.CurrentThread.Name);
            Thread.Sleep(6000);
            
        }
    }
}