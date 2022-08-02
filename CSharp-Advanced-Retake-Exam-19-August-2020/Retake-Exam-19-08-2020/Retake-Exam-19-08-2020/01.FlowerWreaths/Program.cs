using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> lilies = Console.ReadLine().Split(new string(", ")).Select(int.Parse).ToList();
            List<int> roses = Console.ReadLine().Split(new string(", ")).Select(int.Parse).ToList();
            int n = Math.Min(lilies.Count, roses.Count);
            int wreaths = 0, flowers = 0;
            for (int i = 0; i < n; i++)
            {
                while (lilies[lilies.Count - i - 1] + roses[i] > 15)
                {
                    lilies[lilies.Count - i - 1] -= 2;
                }
                if (lilies[lilies.Count - i - 1] + roses[i] == 15)
                {
                    wreaths++;
                }
                else if (lilies[lilies.Count - i - 1] + roses[i] < 15)
                {
                    flowers += lilies[lilies.Count - i - 1] + roses[i];
                }
            }
            wreaths += flowers / 15;
            if (wreaths > 4)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
        }
    }
}
