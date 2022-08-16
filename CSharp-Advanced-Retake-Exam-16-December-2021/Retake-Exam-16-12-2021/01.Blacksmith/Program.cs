using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] steel = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> steels = new Queue<int>(steel);

            int[] carbon = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> carbons = new Stack<int>(carbon);

            int gladius = 0;
            int shamshir = 0;
            int katana = 0;
            int sabre = 0;
            int broadsword = 0;
            int allSword = 0;
            while (carbons.Count > 0 || steels.Count > 0)
            {
                if (steels.Count == 0)
                {
                    break;
                }
                if (carbons.Count == 0)
                {
                    break;
                }
                int curentSteel = steels.Peek();
                int currentCarbon = carbons.Peek();

                if (curentSteel + currentCarbon == 70)
                {
                    gladius++;
                    allSword++;
                    steels.Dequeue();
                    carbons.Pop();
                }
                else if (curentSteel + currentCarbon == 80)
                {
                    shamshir++;
                    allSword++;
                    steels.Dequeue();
                    carbons.Pop();
                }
                else if (curentSteel + currentCarbon == 90)
                {
                    katana++;
                    allSword++;
                    steels.Dequeue();
                    carbons.Pop();
                }
                else if (curentSteel + currentCarbon == 110)
                {
                    sabre++;
                    allSword++;
                    steels.Dequeue();
                    carbons.Pop();
                }
                else if (curentSteel + currentCarbon == 150)
                {
                    broadsword++;
                    allSword++;
                    steels.Dequeue();
                    carbons.Pop();
                }
                else
                {
                    steels.Dequeue();
                    int currentValue = carbons.Pop();
                    int newValue = currentValue + 5;
                    carbons.Push(newValue);
                }

            }

            if (allSword > 0)
            {
                Console.WriteLine($"You have forged {allSword} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            if (steels.Count > 0)
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steels)}");
            }
            else
            {
                Console.WriteLine($"Steel left: none");
            }

            if (carbons.Count > 0)
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbons)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }

            if (broadsword > 0)
            {
                Console.WriteLine($"Broadsword: {broadsword}");
            }
            if (gladius > 0)
            {
                Console.WriteLine($"Gladius: {gladius}");
            }
            if (katana > 0)
            {
                Console.WriteLine($"Katana: {katana}");
            }
            if (sabre > 0)
            {
                Console.WriteLine($"Sabre: {sabre}");
            }
            if (shamshir > 0)
            {
                Console.WriteLine($"Shamshir: {shamshir}");
            }
        }
    }
}
