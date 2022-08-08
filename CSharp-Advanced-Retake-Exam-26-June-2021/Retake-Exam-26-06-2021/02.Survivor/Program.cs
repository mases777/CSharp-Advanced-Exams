using System;

namespace _02.Survivor
{
    public class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] matrix = new char[rows][];

            FillTheJaggedMatrix(matrix);
            var collectedTokens = CollectedTokens(matrix, out var opponentTokens);

            //Console.WriteLine(string.Join(Environment.NewLine, matrix.Select(r => string.Join(" ",r))));
            PrintMatrix(matrix);

            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }
        public static int CollectedTokens(char[][] matrix, out int opponentTokens)
        {
            string command;
            int collectedTokens = 0;
            opponentTokens = 0;

            while ((command = Console.ReadLine().ToLower()) != "gong")
            {
                string[] cmdArr = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (cmdArr.Length == 3)
                {
                    int row = int.Parse(cmdArr[1]);
                    int col = int.Parse(cmdArr[2]);
                    if (isValidIndexes(row, col, matrix))
                    {
                        if (matrix[row][col] == 'T')
                        {
                            collectedTokens += 1;
                            matrix[row][col] = '-';
                        }
                    }
                }
                else
                {
                    int row = int.Parse(cmdArr[1]);
                    int col = int.Parse(cmdArr[2]);
                    string direction = cmdArr[3];

                    if (isValidIndexes(row, col, matrix))
                    {
                        if (matrix[row][col] == 'T')
                        {
                            opponentTokens += 1;
                            matrix[row][col] = '-';
                        }

                        switch (direction)
                        {
                            case "up":

                                for (int i = 1; i <= 3; i++)
                                {
                                    int movement = row - i;

                                    if (isValidIndexes(movement, col, matrix))
                                    {
                                        if (matrix[movement][col] == 'T')
                                        {
                                            opponentTokens += 1;
                                            matrix[movement][col] = '-';
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                //if (isValidIndexes(row - 3, col, matrix))
                                //{
                                //    for (int i = row; i >= 0; i--)
                                //    {
                                //        if (matrix[i][col] == 'T')
                                //        {
                                //            opponentTokens += 1;
                                //            matrix[i][col] = '-';
                                //        }
                                //    }
                                //}

                                break;
                            case "down":
                                for (int i = 1; i <= 3; i++)
                                {
                                    int movement = row + i;

                                    if (isValidIndexes(movement, col, matrix))
                                    {
                                        if (matrix[movement][col] == 'T')
                                        {
                                            opponentTokens += 1;
                                            matrix[movement][col] = '-';
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                //if (isValidIndexes(row + 3, col, matrix))
                                //{
                                //    for (int i = row; i <= row + 3; i++)
                                //    {
                                //        if (matrix[i][col] == 'T')
                                //        {
                                //            opponentTokens += 1;
                                //            matrix[i][col] = '-';
                                //        }
                                //    }
                                //}

                                break;
                            case "left":
                                for (int i = 1; i <= 3; i++)
                                {
                                    int movement = col - i;

                                    if (isValidIndexes(row, movement, matrix))
                                    {
                                        if (matrix[row][movement] == 'T')
                                        {
                                            opponentTokens += 1;
                                            matrix[row][movement] = '-';
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                //if (isValidIndexes(row, col - 3, matrix))
                                //{
                                //    for (int i = col - 3; i >= 0; i--)
                                //    {
                                //        if (matrix[row][i] == 'T')
                                //        {
                                //            opponentTokens += 1;
                                //            matrix[row][i] = '-';
                                //        }
                                //    }
                                //}

                                break;
                            case "right":
                                for (int i = 1; i <= 3; i++)
                                {
                                    int movement = col + i;

                                    if (isValidIndexes(row, movement, matrix))
                                    {
                                        if (matrix[row][movement] == 'T')
                                        {
                                            opponentTokens += 1;
                                            matrix[row][movement] = '-';
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                //if (isValidIndexes(row, col + 3, matrix))
                                //{
                                //    for (int i = col; i <= col + 3; i++)
                                //    {
                                //        if (matrix[row][col] == 'T')
                                //        {
                                //            opponentTokens += 1;
                                //            matrix[row][i] = '-';
                                //        }
                                //    }
                                //}

                                break;
                        }
                    }
                }
            }

            return collectedTokens;
        }

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (var line in matrix)
            {
                var currentLine = string.Join(' ', line);
                Console.WriteLine(currentLine);
            }

            //for (int row = 0; row < matrix.GetLength(0); row++)
            //{
            //    //for (int col = 0; col < matrix[row].Length; col++)
            //    //{
            //    //    Console.Write(matrix[row][col] + " ");
            //    //}

            //    var currentLine = string.Join(' ', matrix[row]);

            //    Console.WriteLine(currentLine);

            //    Console.WriteLine();
            //}
        }

        public static bool isValidIndexes(int row, int col, char[][] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length;
        }

        public static void FillTheJaggedMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] tokensChars = Console.ReadLine().Replace(" ", "").ToCharArray();
                //matrix[row] = new char[tokensChars.Length];
                //for (int cols = 0; cols < matrix[row].Length; cols++)
                //{
                //    if (tokensChars[cols] == ' ')
                //    {
                //        matrix[row][cols] = '-';
                //    }
                //    else
                //    {
                //        matrix[row][cols] = tokensChars[cols];
                //    }
                //}

                matrix[row] = tokensChars;
            }
        }
    }
}
