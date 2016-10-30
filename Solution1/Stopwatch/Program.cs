﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stopwatch
{
    class Program
    {
        private static object _lock = new object();

        public static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            LongOperation("A");
            LongOperation("B");
            LongOperation("C");
            LongOperation("D");
            LongOperation("E");
            stopwatch.Stop();
            Console.WriteLine("Synchronous long operation calls finished {0} sec.", stopwatch.Elapsed.TotalSeconds);
            Console.ReadLine();


            System.Diagnostics.Stopwatch stopwatch2 = new System.Diagnostics.Stopwatch();
            stopwatch2.Start();
            Parallel.Invoke(() => LongOperation("A"),
            () => LongOperation("B"),
            () => LongOperation("C"),
            () => LongOperation("D"),
            () => LongOperation("E"));
            stopwatch2.Stop();
            Console.WriteLine("Parallel long operation calls finished {0} sec.", stopwatch2.Elapsed.TotalSeconds);
            Console.ReadLine();


            System.Diagnostics.Stopwatch stopwatch3 = new System.Diagnostics.Stopwatch();
            stopwatch3.Start();
            Parallel.For(0, 1000, (i) =>
            {
                var x = 2;
                var y = 2;
                var sum = x + y;
            });
            stopwatch3.Stop();
            Console.WriteLine("Parallel calls finished {0} ms.", stopwatch3.Elapsed.TotalMilliseconds);

            stopwatch3.Restart();
            for (int i = 0; i < 1000; i++)
            {
                int x = 2;
                int y = 2;
                int sum = x + y;
            }
            stopwatch3.Stop();
            Console.WriteLine("Sync operation calls finished {0} ms.", stopwatch3.Elapsed.TotalMilliseconds);
            Console.ReadLine();


            int counter = 0;
            Parallel.For(0, 100, (i) =>
            {
                Thread.Sleep(1);
                counter += 1;
            });
            Console.WriteLine("Counter should be 100. Counter is {0}", counter);
            Console.ReadLine();


            int counter2 = 0;
            object objectUsedForLock = new object();
            Parallel.For(0, 100, (i) =>
            {
                Thread.Sleep(1);
                lock (objectUsedForLock)
                {
                    counter2 += 1;
                }
            });
            Console.WriteLine("Counter should be 100. Counter is {0}", counter2);
            Console.ReadLine();


            List<int> results = new List<int>();
            Parallel.For(0, 100, (i) =>
            {
                Thread.Sleep(1);
                lock (_lock)
                {
                    results.Add(i * i);
                }
            });
            Console.WriteLine("Bag length should be 100. Length is {0}", results.Count);
            Console.ReadLine();


            ConcurrentBag<int> iterations = new ConcurrentBag<int>();
            Parallel.For(0, 100, (i) =>
            {
                Thread.Sleep(1);
                iterations.Add(i);
            });
            Console.WriteLine("Bag length should be 100. Length is {0}", iterations.Count);
            Console.ReadLine();
        }

        public static void LongOperation(string taskName)
        {
            Thread.Sleep(1000);
            Console.WriteLine("{0} Finished . Executing Thread : {1}", taskName, Thread.CurrentThread.ManagedThreadId);
        }
    }
}
