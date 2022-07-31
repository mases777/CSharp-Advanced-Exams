using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> liquids = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> ingredients = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int bread = 0, cake = 0, pie = 0, pastry = 0, n = liquids.Count;
            for (int i = 0; i < n; i++)
            {
                if (liquids.Count > 0 && ingredients.Count > 0)
                {
                    int food = liquids[0] + ingredients[ingredients.Count - 1];
                    if (food == 100) pie++;
                    if (food == 75) pastry++;
                    if (food == 50) cake++;
                    if (food == 25) bread++;
                    if (food == 25 || food == 50 || food == 75 || food == 100)
                    {
                        liquids.RemoveAt(0);
                        ingredients.RemoveAt(ingredients.Count - 1);
                    }
                    else
                    {
                        liquids.RemoveAt(0);
                        ingredients[ingredients.Count - 1] += 3;
                    }
                }
            }
            if (bread > 0 && cake > 0 && pie > 0 && pastry > 0)
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            else Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            if (liquids.Count == 0) Console.WriteLine("Liquids left: none");
            else Console.WriteLine("Liquids left: " + string.Join(", ", liquids));
            if (ingredients.Count == 0) Console.WriteLine("Ingredients left: none");
            else
            {
                ingredients.Reverse();
                Console.WriteLine("Ingredients left: " + string.Join(", ", ingredients));
            }
            Console.WriteLine("Bread: {0}", bread);
            Console.WriteLine("Cake: {0}", cake);
            Console.WriteLine("Fruit Pie: {0}", pie);
            Console.WriteLine("Pastry: {0}", pastry);
        }
    }
}
