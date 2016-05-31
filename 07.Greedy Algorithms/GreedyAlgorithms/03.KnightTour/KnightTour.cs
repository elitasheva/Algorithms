using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.KnightTour
{
    public class KnightTour
    {
        private static int size;
        private static int[][] board;

        public static void Main(string[] args)
        {
            size = int.Parse(Console.ReadLine());
            board = new int[size][];

            int startRow = 0;
            int startCol = 0;

            for (int i = 0; i < size; i++)
            {
                board[i] = new int[size];
                for (int j = 0; j < size; j++)
                {
                    board[i][j] = -1;
                }
            }

            board[startRow][startCol] = 1;

            for (int i = 1; i < size * size; i++)
            {
                List<int[]> moves = FindPossibleMoves(startRow, startCol);
                int minMoves = int.MaxValue;
                int index = -1;
                for (int j = 0; j < moves.Count; j++)
                {
                    int[] current = moves[j];
                    int count = FindPossibleMoves(current[0], current[1]).Count;
                    if (count < minMoves)
                    {
                        minMoves = count;
                        index = j;
                    }
                }

                int[] positionToMove = moves[index];
                board[positionToMove[0]][positionToMove[1]] = i + 1;
                startRow = positionToMove[0];
                startCol = positionToMove[1];

            }

            PrintBoard(board);
        }

        private static void PrintBoard(int[][] board)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(board[i][j].ToString().PadLeft(4, ' '));
                }
                Console.WriteLine();
            }
        }

        private static List<int[]> FindPossibleMoves(int startRow, int startCol)
        {
            int[] directions = new[] { 1, 2, -1, 2, 2, 1, 1, -2, -1, -2, -2, 1, 2, -1, -2, -1 };
            List<int[]> moves = new List<int[]>();
            for (int i = 0; i < directions.Length - 1; i += 2)
            {
                int newRow = startRow + directions[i];
                int newCol = startCol + directions[i + 1];
                if (newRow >= 0 && newRow < size && newCol >= 0 && newCol < size && board[newRow][newCol] == -1)
                {
                    moves.Add(new[] { newRow, newCol });
                }
            }

            return moves;
        }
    }
}
