namespace _04.LineInverter
{
    using System;
    using System.Linq;

    public class LineInverter
    {
        private static char[][] matrix;

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            ReadInput(n);

            for (int i = 0; i < 2*n+1; i++)
            {
                int[] dataRow = FindRowData();
                int[] dataCol = FindColData();

                if (dataRow[0] == 0 && dataCol[0] == 0)
                {
                    Console.WriteLine(i);
                    return;
                }

                if (dataRow[0] > dataCol[0])
                {
                    InvertRow(dataRow[1]);
                }
                else
                {
                    InvertCol(dataCol[1]);
                }

            }

            Console.WriteLine(-1);
        }

        private static void InvertCol(int col)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                if (matrix[row][col] == 'W')
                {
                    matrix[row][col] = 'B';
                }
                else
                {
                    matrix[row][col] = 'W';
                }
            }
        }

        private static void InvertRow(int row)
        {
            for (int col = 0; col < matrix.Length; col++)
            {
                if (matrix[row][col] == 'W')
                {
                    matrix[row][col] = 'B';
                }
                else
                {
                    matrix[row][col] = 'W';
                }
            }
        }

        private static int[] FindColData()
        {
            int maxCount = 0;
            int coll = - 1;
            for (int col = 0; col < matrix.Length; col++)
            {
                int currentCount = 0;
                for (int row = 0; row < matrix.Length; row++)
                {
                    if (matrix[row][col] == 'W')
                    {
                        currentCount++;
                    }
                }

                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                    coll = col;
                }
            }

            return new[] {maxCount, coll};
        }

        private static int[] FindRowData()
        {
            int maxCount = 0;
            int row = -1;
            for (int i = 0; i < matrix.Length; i++)
            {
                int currentCount = matrix[i].Where(a => a == 'W').Count();
                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                    row = i;
                }
            }

            return new[] {maxCount, row};
        }

        private static void ReadInput(int n)
        {
            matrix = new char[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }
        }
    }
}
