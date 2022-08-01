using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> tasks = Console.ReadLine().Split(new string(", ")).Select(int.Parse).ToList();
            List<int> threads = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int killTask = int.Parse(Console.ReadLine());

            int threadValue = 0, n = Math.Max(tasks.Count, threads.Count);
            for (int i = 0; i < n; i++)
            {
                if (tasks.Count > 0 && threads.Count > 0)
                {
                    if (tasks[tasks.Count - 1] == killTask)
                    {
                        threadValue = threads[0]; break;
                    }
                    if (threads[0] >= tasks[tasks.Count - 1])
                    {
                        threads.RemoveAt(0);
                        tasks.RemoveAt(tasks.Count - 1);
                    }
                    else threads.RemoveAt(0);
                }
            }
            if (threadValue > 0)
            {
                Console.WriteLine("Thread with value {0} killed task {1}", threadValue, killTask);
                Console.WriteLine(string.Join(" ", threads));
            }
        }
    }
}
