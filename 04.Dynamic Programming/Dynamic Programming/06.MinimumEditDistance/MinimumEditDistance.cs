namespace _06.MinimumEditDistance
{
    using System;
    using System.Collections.Generic;

    public class MinimumEditDistance
    {
        private static Dictionary<string, int> costs = new Dictionary<string, int>();

        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input.Contains("cost"))
            {
                string[] data = input.Split(new[] { '-', '=' }, StringSplitOptions.RemoveEmptyEntries);
                string operation = data[1].Trim();
                int cost = int.Parse(data[2].Trim());

                costs.Add(operation, cost);
                input = Console.ReadLine();
            }

            string str1 = input.Split('=')[1].Trim();
            string str2 = Console.ReadLine().Split('=')[1].Trim();

            int[,] matrix = new int[str2.Length + 1, str1.Length + 1];
            matrix[0, 0] = 0;
            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                matrix[row, 0] = row;
            }

            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                matrix[0, col] = col;
            }

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (str2[i - 1] == str1[j - 1])
                    {
                        matrix[i, j] = matrix[i - 1, j - 1];
                    }
                    else
                    {
                        matrix[i, j] = Math.Min(matrix[i - 1, j], Math.Min(matrix[i - 1, j - 1], matrix[i, j - 1])) + 1;
                    }
                }
            }

            PrintMatrix(matrix);

            int totalCost = 0;
            int m = matrix.GetLength(0)-1;
            int n = matrix.GetLength(1)-1;
            while (m > 0 && n > 0)
            {
                if (str2[m - 1] == str1[n - 1])
                {
                    m--;
                    n--;
                    continue;
                }

                if (matrix[m, n] == 1 + matrix[m - 1, n - 1])
                {
                    m--;
                    n--;
                    if (costs["replace"] > costs["delete"] + costs["insert"])
                    {
                        totalCost += costs["delete"] + costs["insert"];
                        Console.WriteLine("delete + insert");
                    }
                    else
                    {
                        totalCost += costs["replace"];
                        Console.WriteLine("replace");
                    }
                }
                else if (matrix[m, n] == 1 + matrix[m - 1, n])
                {
                    m--;
                    totalCost += costs["insert"];
                    Console.WriteLine("insert");
                }
                else if (matrix[m, n] == 1 + matrix[m, n - 1])
                {
                    n--;
                    totalCost += costs["delete"];
                    Console.WriteLine("delete");
                }
            }

            while (n > 0)
            {
                n--;
                totalCost += costs["delete"];
                Console.WriteLine("delete");
            }

            while (m > 0)
            {
                m--;
                totalCost += costs["insert"];
                Console.WriteLine("insert");
            }

            Console.WriteLine(totalCost);
         
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,3}", matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
