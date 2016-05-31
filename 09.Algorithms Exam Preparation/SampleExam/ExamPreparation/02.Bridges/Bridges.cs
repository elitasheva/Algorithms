namespace _02.Bridges
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Bridges
    {
        public static void Main(string[] args)
        {
            int[] north = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] south = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            List<int> indeces = new List<int>();
            for (int i = 0; i < north.Length; i++)
            {
                for (int j = 0; j < south.Length; j++)
                {
                    if (north[i] == south[j])
                    {
                         indeces.Add(j);
                    }
                }
            }

            List<int> result = new List<int>();
            int[] len = new int[indeces.Count];
            int[] prev = new int[indeces.Count];

            int maxLen = 0;
            int lastIndex = -1;
            for (int i = 0; i < indeces.Count; i++)
            {
                len[i] = 1;
                prev[i] = -1;
                for (int j = 0; j < i; j++)
                {
                    if (indeces[j] <= indeces[i] && len[j] + 1 > len[i])
                    {
                        len[i] = len[j] + 1;
                        prev[i] = j;
                    }
                }

                if (len[i] > maxLen)
                {
                    maxLen = len[i];
                    lastIndex = i;
                }
            }

            while (lastIndex != -1)
            {
                result.Add(indeces[lastIndex]);
                lastIndex = prev[lastIndex];
            }

            Console.WriteLine(result.Count);
        }
    }
}
