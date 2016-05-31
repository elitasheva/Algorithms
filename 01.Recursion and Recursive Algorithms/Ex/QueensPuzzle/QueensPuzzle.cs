using System;
using System.Collections.Generic;


namespace QueensPuzzle
{
    class QueensPuzzle
    {
        const int Size = 8;
        static bool[,] chessboard = new bool[Size, Size];
        static int solutionsFound = 0;

        //static HashSet<int> attackedRows = new HashSet<int>();
       // static HashSet<int> attackedCols = new HashSet<int>();
       // static HashSet<int> attackedLeftDiagonal = new HashSet<int>();
        //static HashSet<int> attackedRightDiagonal = new HashSet<int>();
        static bool[] attackedCols = new bool[Size];
        static bool[] attackedLeftDiagonals = new bool[15];
        static bool[] attackedRightDiagonals = new bool[15];

        static void Main(string[] args)
        {
            PutQueen(0);
            Console.WriteLine(solutionsFound);
        }

        static void PutQueen(int row)
        {
            if (row == Size)
            {
                PrintSolution();
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if (CanPlaseQueen(row, col))
                    {
                        MarkAllAttackedPositions(row, col);
                        PutQueen(row + 1);
                        UnmarkAllAttackedPositions(row, col);
                    }
                }
            }
        }

        private static void PrintSolution()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (chessboard[i,j])
                    {
                        Console.Write("*"+ " ");
                    }
                    else
                    {
                        Console.Write("-" + " ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            solutionsFound++;
        }

        private static void UnmarkAllAttackedPositions(int row, int col)
        {
            //attackedRows.Remove(row);
            //attackedCols.Remove(col);
            //attackedLeftDiagonal.Remove(col - row);
            //attackedRightDiagonal.Remove(row + col);
            attackedCols[col] = false;
            attackedLeftDiagonals[(col - row) + 7] = false;
            attackedRightDiagonals[row + col] = false;

            chessboard[row, col] = false;
        }

        private static void MarkAllAttackedPositions(int row, int col)
        {
            //attackedRows.Add(row);
            //attackedCols.Add(col);
            //attackedLeftDiagonal.Add(col - row);
            //attackedRightDiagonal.Add(row + col);
            attackedCols[col] = true;
            attackedLeftDiagonals[(col - row) + 7] = true;
            attackedRightDiagonals[row + col] = true;
            chessboard[row, col] = true;
        }

        private static bool CanPlaseQueen(int row, int col)
        {
            //var position = attackedRows.Contains(row) ||
            //               attackedCols.Contains(col) ||
            //               attackedLeftDiagonal.Contains(col - row) ||
            //               attackedRightDiagonal.Contains(row + col);

            var position = attackedCols[col] ||
                           attackedLeftDiagonals[(col - row) + 7] ||
                           attackedRightDiagonals[row + col];

            return !position;

        }
    }


}
