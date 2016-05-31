namespace _07.ConnectedAreasInMatrix
{
    using System;
    using System.Collections.Generic;

    public class Area : IComparable<Area>
    {
        public int Size { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int CompareTo(Area other)
        {
            int result = other.Size.CompareTo(this.Size);

            if (result == 0)
            {
                result = this.X.CompareTo(other.X);

                if (result == 0)
                {
                    result = this.Y.CompareTo(other.Y);
                }
            }

            return result;
        }
    }

    public class ConnectedAreasInMatrix
    {
        private static int counter = 0;

        public static void Main(string[] args)
        {
            char[,] matrix1 =
            {
                {' ', ' ', ' ', '*',' ', ' ', ' ', '*',' '},
                {' ', ' ', ' ', '*',' ', ' ', ' ', '*',' '},
                {' ', ' ', ' ', '*',' ', ' ', ' ', '*',' '},
                {' ', ' ', ' ', ' ','*', ' ', '*', ' ',' '},

            };

            char[,] matrix2 =
           {
                {'*', ' ', ' ', '*',' ', ' ',' ', '*', ' ', ' '},
                {'*', ' ', ' ', '*',' ', ' ',' ', '*', ' ', ' '},
                {'*', ' ', ' ', '*','*', '*','*', '*', ' ', ' '},
                {'*', ' ', ' ', '*',' ', ' ',' ', '*', ' ', ' '},
                {'*', ' ', ' ', '*',' ', ' ',' ', '*', ' ', ' '},

            };

            SortedSet<Area> areas = new SortedSet<Area>();

            while (true)
            {
                int[] cell = FindCell(matrix1);     //change matrix to test
                if (cell[0] == -1 && cell[1] == -1)
                {
                    break;
                }
                Area area = new Area();
                area.X = cell[0];
                area.Y = cell[1];
                FindArea(matrix1, cell[0], cell[1]);   //change matrix to test
                area.Size = counter;
                areas.Add(area);
                counter = 0;
            }

            Console.WriteLine("Total areas found: {0}", areas.Count);
            int count = 0;
            foreach (var area in areas)
            {
                count++;
                Console.WriteLine("Area #{0} at ({1}, {2}), size: {3}", count, area.X, area.Y, area.Size);
            }

        }

        private static int[] FindCell(char[,] matrix)
        {
            int[] cell = new int[2];
            bool found = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == ' ')
                    {
                        cell[0] = i;
                        cell[1] = j;
                        found = true;
                        break;
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

        private static void FindArea(char[,] matrix, int row, int col)
        {
            if (!IsValidPosition(matrix, row, col) || matrix[row, col] != ' ')
            {
                return;
            }


            matrix[row, col] = '.';
            counter++;
            FindArea(matrix, row - 1, col);
            FindArea(matrix, row, col - 1);
            FindArea(matrix, row + 1, col);
            FindArea(matrix, row, col + 1);
        }

        private static bool IsValidPosition(char[,] matrix1, int row, int col)
        {
            return row >= 0 && row < matrix1.GetLength(0) &&
                col >= 0 && col < matrix1.GetLength(1);
        }
    }
}
