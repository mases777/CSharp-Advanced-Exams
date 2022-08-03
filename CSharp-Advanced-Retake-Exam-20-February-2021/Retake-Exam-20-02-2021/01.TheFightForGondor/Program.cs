using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TheFightForGondor
{
    public class Program
    {
        static void Main(string[] args)
        {
            var waves = int.Parse(Console.ReadLine());
            var plates = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var orcsToPrint = new Queue<int>();
            int check = 0;
            for (int i = 1; i <= waves; i++)
            {
                var newWaveOrcs = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

                var curPlate = plates.Peek();
                if (i % 3 == 0) check = 1;
                while (newWaveOrcs.Count != 0 && plates.Count != 0)
                {
                    var curOrc = newWaveOrcs.Peek();
                    if (curPlate > curOrc)
                    {
                        curPlate -= curOrc;
                        newWaveOrcs.Pop();
                    }
                    else if (curOrc > curPlate)
                    {
                        curOrc -= curPlate;
                        plates.Dequeue();
                        newWaveOrcs.Pop();
                        newWaveOrcs.Push(curOrc);
                        if (plates.Count != 0) curPlate = plates.Peek();
                    }
                    else
                    {
                        curPlate -= curOrc;
                        plates.Dequeue();
                        newWaveOrcs.Pop();
                    }
                    if (check == 1)
                    {
                        int plateToAdd = int.Parse(Console.ReadLine());
                        plates.Enqueue(plateToAdd);
                        check++;
                    }
                }

                if (newWaveOrcs.Count == 0 && curPlate > 0)
                {
                    plates.Dequeue();
                    plates.Enqueue(curPlate);
                }

                if (newWaveOrcs.Count > 0 && plates.Count == 0)
                {
                    int n = newWaveOrcs.Count;
                    for (int j = 0; j < n; j++)
                    {
                        orcsToPrint.Enqueue(newWaveOrcs.Pop());
                    }
                    break;
                }
            }

            if (plates.Count <= 0)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcsToPrint)}");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}
