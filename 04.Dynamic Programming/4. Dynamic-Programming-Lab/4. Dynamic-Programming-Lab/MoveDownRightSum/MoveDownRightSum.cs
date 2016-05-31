namespace MoveDownRightSum
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class MoveDownRightSum
    {
        public static void Main(string[] args)
        {
            int[,] matrix =
            {
                {2,6,1,8,9,4,2},
                {1,8,0,3,5,6,7},
                {3,4,8,7,2,1,8},
                {0,9,2,8,1,7,9},
                {2,7,1,9,7,8,2},
                {4,5,6,1,2,5,6},
                {9,3,5,2,8,1,9},
                {2,3,4,1,7,2,8}
            };

            int[,] newMatrix = new int[matrix.GetLength(0),matrix.GetLength(1)];

            newMatrix[0,0] = matrix[0,0];
            for (int i = 1; i < newMatrix.GetLength(0); i++)
            {
                newMatrix[i, 0] = newMatrix[i - 1, 0] + matrix[i, 0];
            }

            for (int i = 1; i < newMatrix.GetLength(1); i++)
            {
                newMatrix[0, i] = newMatrix[0, i - 1] + matrix[0, i];
            }

            for (int i = 1; i < newMatrix.GetLength(0); i++)
            {
                for (int j = 1; j < newMatrix.GetLength(1); j++)
                {
                    int max = Math.Max(newMatrix[i, j - 1], newMatrix[i - 1, j]);
                    newMatrix[i, j] = max + matrix[i, j];
                }
            }

            var path = ReconstructPath(newMatrix);

            PrintMatrix(newMatrix, path);
        }

        private static HashSet<Tuple<int, int>> ReconstructPath(int[,] newMatrix)
        {
            var path = new HashSet<Tuple<int,int>>();
            int row = newMatrix.GetLength(0) - 1;
            int col = newMatrix.GetLength(1) - 1;
            path.Add(new Tuple<int, int>(row, col));
            while (row > 0 && col > 0)
            {
                if (newMatrix[row - 1, col] > newMatrix[row, col - 1])
                {
                    path.Add(new Tuple<int, int>(row - 1, col));
                    row--;
                }
                else
                {
                    path.Add(new Tuple<int, int>(row, col - 1));
                    col--;
                }
            }

            if (row == 0)
            {
                while (col > 0)
                {
                    path.Add(new Tuple<int, int>(row, col - 1));
                    col--;
                }
            }

            if (col == 0)
            {
                while (row > 0)
                {
                    path.Add(new Tuple<int, int>(row - 1, col));
                    row--;
                }
            }

            return path;
        }

        private static void PrintMatrix(int[,] newMatrix, HashSet<Tuple<int, int>> path)
        {
            for (int i = 0; i < newMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < newMatrix.GetLength(1); j++)                                                  
                {
                    if (path.Contains(new Tuple<int, int>(i,j)))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Write("{0,3}",newMatrix[i,j] + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
        }
    }
}
