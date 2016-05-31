namespace _06._1.MinimumEditDistance
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MinimumEditDistance
    {
        private static Dictionary<string, int> costs = new Dictionary<string, int>();
        private static List<string> result = new List<string>(); 

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

            int m = str1.Length;
            int n = str2.Length;

            int totalCost = FindMinimumeditDistance(str1, str2, m, n);
            
            Console.WriteLine("Minimum edit distance: " + totalCost);
            if (result.Count > 0)
            {
                result.Reverse();
                foreach (var str in result)
                {
                    Console.WriteLine(str);
                }
            }

        }

        private static int FindMinimumeditDistance(string str1, string str2, int m, int n)
        {
            int[][] matrix = new int[m + 1][];

            for (int i = 0; i < m; i++)
            {
                matrix[i] = new int[n + 1];
                for (int j = 0; j < n; j++)
                {
                    if (i == 0)
                    {
                        matrix[i][j] = j;    //if str1 is empty
                    }
                    else if (j == 0)
                    {
                        matrix[i][j] = i;    // if str2 is empty
                    }
                    else if (str1[i - 1] == str2[j - 1])
                    {
                        matrix[i][j] = matrix[i - 1][j - 1];  //if chars are equal, increase diagonal
                    }
                    else
                    {
                        matrix[i][j] = 1 + Math.Min(Math.Min(matrix[i][j - 1],   //insert a character in str1
                            matrix[i - 1][j]),                                   //remove a character from str1
                            matrix[i - 1][j - 1]);                               //replace the corresponding character from str1
                    }
                }
            }
            m--;
            n--;
            int totalCost = 0;
            while (m > 0 && n > 0)
            {
                if (str1[m - 1] == str2[n - 1])
                {
                    m--;
                    n--;
                    continue;
                }

                if (matrix[m][n] == 1 + matrix[m - 1][n - 1])
                {
                    if (costs["replace"] > costs["delete"] + costs["insert"])
                    {
                        totalCost += costs["delete"] + costs["insert"];
                        //Console.WriteLine("Insert {0} in str1 at pos {1}", str2[n - 1], m - 1);
                        //Console.WriteLine("Delete {0} in str1 at pos {1}", str1[m - 1], m - 1);
                        result.Add(string.Format("Insert({0},{1})", m - 1, str2[n - 1]));
                        result.Add(string.Format("Delete({0})", m-1));
                        
                    }
                    else
                    {
                        totalCost += costs["replace"];
                        //Console.WriteLine("Replace {0} in str1 with {1} from str2 at pos {2}", str1[m - 1], str2[n - 1], m - 1);
                        result.Add(string.Format("Replace({0},{1})", m - 1, str2[n - 1]));
                    }

                    m--;
                    n--;

                }
                else if (matrix[m][n] == 1 + matrix[m][n - 1])
                {
                    //Console.WriteLine("Insert {0} in str1 at pos {1}", str2[n - 1], m-1);
                    result.Add(string.Format("Insert({0},{1})", m - 1, str2[n - 1]));
                    totalCost += costs["insert"];
                    n--;
                }
                else if (matrix[m][n] == 1 + matrix[m - 1][n])
                {
                    //Console.WriteLine("Delete {0} from str1 at pos {1}", str1[m - 1], m - 1);
                    result.Add(string.Format("Delete({0})", m - 1));
                    totalCost += costs["delete"];
                    m--;
                }
            }

            while (m > 0)
            {
                //Console.WriteLine("Delete {0} from str1 at pos {1}", str1[m - 1], m - 1);
                result.Add(string.Format("Delete({0})", m - 1));
                totalCost += costs["delete"];
                m--;
            }

            while (n > 0)
            {
                //Console.WriteLine("Insert {0} in str1 at pos {1}", str2[n - 1], n-1);
                result.Add(string.Format("Insert({0},{1})", m, str2[n - 1]));
                totalCost += costs["insert"];
                n--;
            }


            return totalCost;
        }
    }
}
