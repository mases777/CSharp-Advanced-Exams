using System;
using System.Linq;

namespace _02.Garden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] squareArea = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[,] garden = new int[squareArea[0], squareArea[1]];
            for (int i = 0; i < squareArea[0]; i++)
                for (int j = 0; j < squareArea[1]; j++)
                    garden[i, j] = 0;

            var line = Console.ReadLine();
            while (line != "Bloom Bloom Plow")
            {
                int[] coordinate = line.Split(' ').Select(int.Parse).ToArray();
                if (coordinate[0] > squareArea[0] - 1 || coordinate[1] > squareArea[1] - 1 ||
                    coordinate[0] < 0 || coordinate[1] < 0)
                    Console.WriteLine("Invalid coordinates.");
                else
                {
                    garden[coordinate[0], coordinate[1]] = 1;
                }
                line = Console.ReadLine();
            }

            int[,] gardenResult = new int[squareArea[0], squareArea[1]];
            for (int m = 0; m < squareArea[0]; m++)
                for (int n = 0; n < squareArea[1]; n++)
                {
                    for (int i = 0; i < squareArea[0]; i++)
                        gardenResult[m, n] += garden[i, n];
                    for (int j = 0; j < squareArea[1]; j++)
                        gardenResult[m, n] += garden[m, j];
                    gardenResult[m, n] -= garden[m, n];
                }

            for (int i = 0; i < squareArea[0]; i++)
            {
                for (int j = 0; j < squareArea[1]; j++)
                {
                    Console.Write(gardenResult[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
