using System;
using System.Linq;

namespace _02.SuperMario
{
    class Program
    {
        public static char[][] matrix;
        public static int marioRow;
        public static int marioCol;
        public static int lives;
        public static bool isPrincesSave = false;
        public static bool isMarioDie = false;
        static void Main(string[] args)
        {
            lives = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            if (n == 0)
            {
                return;
            }

            matrix = new char[n][];
            FillMatrix(n);

            while (true)
            {
                string[] comands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string action = comands[0];
                int enemyRow = int.Parse(comands[1]);
                int enemyCol = int.Parse(comands[2]);

                matrix[enemyRow][enemyCol] = 'B';

                if (action == "W")
                {
                    Move(-1, 0);
                }
                else if (action == "S")
                {
                    Move(1, 0);
                }
                else if (action == "A")
                {
                    Move(0, -1);
                }
                else if (action == "D")
                {
                    Move(0, 1);
                }
                if (isMarioDie)
                {
                    break;
                }
                if (isPrincesSave)
                {
                    break;
                }
            }
            if (isPrincesSave)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }
            else if (isMarioDie)
            {
                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
            }
            PrintMatrix();
        }
        public static void Move(int row, int col)
        {
            lives -= 1;

            if (IsValid(marioRow + row, marioCol + col))
            {
                matrix[marioRow][marioCol] = '-';
                marioRow += row;
                marioCol += col;

                if (matrix[marioRow][marioCol] == 'P')
                {
                    matrix[marioRow][marioCol] = '-';
                    isPrincesSave = true;
                    return;
                }

                if (lives <= 0)
                {
                    isMarioDie = true;
                    matrix[marioRow][marioCol] = 'X';
                    return;
                }

                if (matrix[marioRow][marioCol] == 'B')
                {
                    lives -= 2;
                    if (lives <= 0)
                    {
                        matrix[marioRow][marioCol] = 'X';
                        isMarioDie = true;
                    }
                    else
                    {
                        matrix[marioRow][marioCol] = 'M';
                    }
                    return;
                }

                if (matrix[marioRow][marioCol] == '-')
                {
                    matrix[marioRow][marioCol] = 'M';
                }
            }

            if (lives <= 0)
            {
                isMarioDie = true;
                matrix[marioRow][marioCol] = 'X';
                return;
            }
        }
        public static bool IsValid(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                    col >= 0 && col < matrix[row].Length;
        }
        public static void PrintMatrix()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(row);
            }
        }
        public static void FillMatrix(int n)
        {
            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                matrix[row] = new char[input.Length];
                matrix[row] = input;
                for (int col = 0; col < input.Length; col++)
                {
                    if (matrix[row][col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }
                }
            }
        }
    }
}
