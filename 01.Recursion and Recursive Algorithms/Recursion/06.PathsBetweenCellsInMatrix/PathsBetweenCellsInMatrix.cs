namespace _06.PathsBetweenCellsInMatrix
{
    using System;
    using System.Collections.Generic;

    public class PathsBetweenCellsInMatrix
    {
        private static int countPaths = 0;
        private static List<string> paths = new List<string>();

        public static void Main(string[] args)
        {
            char[,] matrix1 =
            {
                {' ', ' ', ' ', ' '},
                {' ', '*', '*', ' '},
                {' ', '*', '*', ' '},
                {' ', '*', 'e', ' '},
                {' ', ' ', ' ', ' '}

            };

            char[,] matrix2 =
           {
                {' ', ' ', ' ', ' ',' ', ' '},
                {' ', '*', '*', ' ','*', ' '},
                {' ', '*', '*', ' ','*', ' '},
                {' ', '*', 'e', ' ',' ', ' '},
                {' ', ' ', ' ', '*',' ', ' '},

            };

            FindPath(matrix1, 0, 0, "");
            Console.WriteLine("Total paths found: " + countPaths);
        }

        private static void FindPath(char[,] matrix, int row, int col, string path)
        {
            if (!IsValidPosition(row, col, matrix))
            {
                return;
            }

            if (matrix[row, col] == 'e')
            {
                countPaths++;
                paths.Add(path);
                PrintMatrix(matrix);
                Console.WriteLine(string.Join("",paths));
                paths.RemoveAt(paths.Count - 1);

            }

            if (matrix[row, col] != ' ')
            {
                return;
            }

            matrix[row, col] = '.';
            paths.Add(path);
            FindPath(matrix, row - 1, col, "U");
            FindPath(matrix, row, col - 1, "L");
            FindPath(matrix, row + 1, col, "D");
            FindPath(matrix, row, col + 1, "R");
            matrix[row, col] = ' ';
            paths.RemoveAt(paths.Count-1);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static bool IsValidPosition(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
