using System;
using System.Threading;

namespace Lecture6
{
    internal class Program
    {
        private static object SyncRoot = new object();

        private static EventWaitHandle e1 = new EventWaitHandle(false, EventResetMode.ManualReset);

        private static EventWaitHandle e2 = new EventWaitHandle(false, EventResetMode.ManualReset);

        private static int a = 100;

        private static int b = 200;

        private static int c = 100;

        private static int d = 200;

        private static int t1 = 0;

        private static int t2 = 0;

        private static int r = 0;

        private static void Main(string[] args)
        {
            var thread2 = new Thread(() =>
            {
                e1.WaitOne();
                t1 = t1 * t1;
            });

            var thread1 = new Thread(() =>
            {
                t1 = a + b;
                e1.Set();
                t2 = c + d;
                thread2.Join();
                r = t1 + t2;
            });

            thread2.Start();
            thread1.Start();

            thread1.Join();
            Console.WriteLine(r);
            Console.WriteLine((a + b) * (a + b) + c + d);

            var threads = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(Do);
            }

            threads[0].Priority = ThreadPriority.Highest;
            threads[8].Priority = ThreadPriority.Lowest;

            for (int i = 0; i < 10; i++)
            {
                threads[i].Start(i);
            }
        }

        private static void Do(object arg)
        {
            for (int i = 0; i < 1000; i++)
            {
                lock (SyncRoot)
                {
                    Console.BackgroundColor = (ConsoleColor)arg;
                    Console.Write(arg);
                }
            }
        }
    }
}