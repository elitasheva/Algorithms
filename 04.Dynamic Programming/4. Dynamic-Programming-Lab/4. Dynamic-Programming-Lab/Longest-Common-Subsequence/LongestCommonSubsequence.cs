namespace Longest_Common_Subsequence
{
    using System;
    using System.Collections.Generic;

    public class LongestCommonSubsequence
    {
        public static void Main()
        {
            var firstStr = "tree";
            var secondStr = "team";

            var lcs = FindLongestCommonSubsequence(firstStr, secondStr);

            Console.WriteLine("Longest common subsequence:");
            Console.WriteLine("  first  = {0}", firstStr);
            Console.WriteLine("  second = {0}", secondStr);
            Console.WriteLine("  lcs    = {0}", lcs);
        }

        public static string FindLongestCommonSubsequence(string firstStr, string secondStr)
        {
            int firstLen = firstStr.Length + 1;
            int secondLen = secondStr.Length + 1;
            int[,] matrix = new int[firstLen, secondLen];

            for (int i = 1; i < firstLen; i++)
            {
                for (int j = 1; j < secondLen; j++)
                {
                    if (firstStr[i - 1] == secondStr[j - 1])
                    {
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        matrix[i, j] = Math.Max(matrix[i - 1, j], matrix[i, j - 1]);
                    }
                }
            }

            var result = RetrieveLCS(firstStr, secondStr, matrix);
            //PrintMatrix(matrix);
            result.Reverse();
            return string.Join("", result);

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

        private static List<char> RetrieveLCS(string firstStr, string secondStr, int[,] matrix)
        {
            int i = firstStr.Length;
            int j = secondStr.Length;

            List<char> result = new List<char>();
            while (i > 0 && j > 0)
            {
                if (firstStr[i-1] == secondStr[j-1])
                {
                   result.Add(firstStr[i-1]);
                    i--;
                    j--;
                }
                else if (matrix[i,j] == matrix[i-1,j])
                {
                    i--;
                }
                else
                {
                    j--;
                }
            }

            return result;
        }
    }
}

