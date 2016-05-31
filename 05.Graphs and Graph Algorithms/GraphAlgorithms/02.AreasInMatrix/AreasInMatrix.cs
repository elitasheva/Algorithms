namespace _02.AreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AreasInMatrix
    {
        private static SortedDictionary<char, int> areas = new SortedDictionary<char, int>();
        private static char[][] matrix;
        public static void Main(string[] args)
        {
            ReadInput();
            while (true)
            {
                int[] cell = FindCell();
                if (cell[0] == -1 && cell[1] == -1)
                {
                    break;
                }

                var currentSymbol = matrix[cell[0]][cell[1]];
                FindArea(cell[0], cell[1], currentSymbol);
                if (!areas.ContainsKey(currentSymbol))
                {
                    areas.Add(currentSymbol, 0);
                }
                areas[currentSymbol]++;
            }

           Console.WriteLine("Areas: " + areas.Values.Sum());
            foreach (var area in areas)
            {
                Console.WriteLine("Letter '{0}' -> {1}",area.Key,area.Value); 
            }

        }

        private static void ReadInput()
        {
            int n = int.Parse(Console.ReadLine());
            matrix = new char[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }
        }

        private static int[] FindCell()
        {
            int[] cell = new int[2];
            bool found = false;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] != '.')
                    {
                        cell[0] = i;
                        cell[1] = j;
                        found = true;
                    }

                }
                if (found)
                {
                    break;
                }
            }
            if (!found)
            {
                cell[0] = -1;
                cell[1] = -1;
            }

            return cell;
        }

        private static void FindArea(int row, int col, char currentSymbol)
        {
            if (!IsValidPosition(row, col) || matrix[row][col] != currentSymbol)
            {
                return;
            }


            matrix[row][col] = '.';
            //counter++;
            FindArea(row - 1, col, currentSymbol);
            FindArea(row, col - 1, currentSymbol);
            FindArea(row + 1, col, currentSymbol);
            FindArea(row, col + 1, currentSymbol);
        }

        private static bool IsValidPosition(int row, int col)
        {
            return row >= 0 && row < matrix.Length &&
                col >= 0 && col < matrix[row].Length;
        }
    }
}
