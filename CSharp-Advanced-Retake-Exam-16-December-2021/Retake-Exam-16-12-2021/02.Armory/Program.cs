using System;

namespace _02.Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            char[,] armory = new char[n, n];
            FillMatrix(n, armory);
            int sum = 0;
            char startPosition = armory[0, 0];
            int indexRow = 0, indexCol = 0;
            StartPosition(n, armory, ref startPosition, ref indexRow, ref indexCol);
            armory[indexRow, indexCol] = '-';
            while (true)
            {
                string command = Console.ReadLine();
                switch (command)
                {
                    case "up":
                        {
                            indexRow--;
                            if (!IsValid(indexRow, indexCol, n)) break;
                            Pillars(n, armory, ref indexRow, ref indexCol);
                            if (char.IsDigit(armory[indexRow, indexCol]))
                                sum += (int)armory[indexRow, indexCol] - 48;
                            armory[indexRow, indexCol] = '-';
                            break;
                        }
                    case "down":
                        {
                            indexRow++;
                            if (!IsValid(indexRow, indexCol, n)) break;
                            Pillars(n, armory, ref indexRow, ref indexCol);
                            if (char.IsDigit(armory[indexRow, indexCol]))
                                sum += (int)armory[indexRow, indexCol] - 48;
                            armory[indexRow, indexCol] = '-';
                            break;
                        }
                    case "left":
                        {
                            indexCol--;
                            if (!IsValid(indexRow, indexCol, n)) break;
                            Pillars(n, armory, ref indexRow, ref indexCol);
                            if (char.IsDigit(armory[indexRow, indexCol]))
                                sum += (int)armory[indexRow, indexCol] - 48;
                            armory[indexRow, indexCol] = '-';
                            break;
                        }
                    case "right":
                        {
                            indexCol++;
                            if (!IsValid(indexRow, indexCol, n)) break;
                            Pillars(n, armory, ref indexRow, ref indexCol);
                            if (char.IsDigit(armory[indexRow, indexCol]))
                                sum += (int)armory[indexRow, indexCol] - 48;
                            armory[indexRow, indexCol] = '-';
                            break;
                        }
                }
                if (!IsValid(indexRow, indexCol, n)) break;
                if (sum >= 65)
                {
                    armory[indexRow, indexCol] = 'A'; break;
                }
            }
            if (sum >= 65)
                Console.WriteLine("Very nice swords, I will come back for more!");
            else Console.WriteLine("I do not need more swords!");
            Console.WriteLine($"The king paid {sum} gold coins.");
            PrintMatrix(n, armory);
        }
        private static void Pillars(int n, char[,] armory, ref int indexRow, ref int indexCol)
        {
            if (armory[indexRow, indexCol] == 'M')
            {
                armory[indexRow, indexCol] = '-';
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                    {
                        if (armory[i, j] == 'M')
                        {
                            indexRow = i;
                            indexCol = j;
                            armory[indexRow, indexCol] = '-';
                        }
                    }
            }
        }

        private static bool IsValid(int indexRow, int indexCol, int n)
        {
            if (indexRow < 0 || indexRow > n - 1 || indexCol < 0 || indexCol > n - 1)
                return false;
            return true;
        }

        private static void StartPosition(int n, char[,] armory, ref char startPosition, ref int indexRow, ref int indexCol)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (armory[i, j] == 'A')
                    {
                        startPosition = armory[i, j];
                        indexRow = i; indexCol = j;
                        break;
                    }
                }
                if (startPosition != armory[0, 0]) break;
            }
        }

        private static void PrintMatrix(int n, char[,] armory)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(armory[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void FillMatrix(int n, char[,] armory)
        {
            for (int i = 0; i < n; i++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                for (int j = 0; j < n; j++)
                {
                    armory[i, j] = line[j];
                }
            }
        }
    }
}
