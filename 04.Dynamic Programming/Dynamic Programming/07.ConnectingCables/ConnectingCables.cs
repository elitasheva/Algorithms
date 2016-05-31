namespace _07.ConnectingCables
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ConnectingCables
    {
        public static void Main(string[] args)
        {
            int[] north =
                Console.ReadLine().Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[1]
                .Trim()
                .Split(new[] { ',', '{', '}' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int[] south =
                Console.ReadLine().Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[1]
                .Trim()
                .Split(new[] { ',', '{', '}' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();


            List<int> indeces = new List<int>();
            for (int i = 0; i < north.Length; i++)
            {
                for (int j = 0; j < south.Length; j++)
                {
                    if (north[i] == south[j])
                    {
                        indeces.Add(j);
                        break;
                    }
                }
            }

            int[] prev = new int[indeces.Count];
            int[] len = new int[indeces.Count];
            int maxLen = 0;
            int lastIndex = -1;
            for (int i = 0; i < indeces.Count; i++)
            {
                prev[i] = - 1;
                len[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (indeces[j] < indeces[i] && len[i] < len[j] + 1)
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

            List<int> result = new List<int>();
            while (lastIndex != -1)
            {
                result.Add(indeces[lastIndex]);
                lastIndex = prev[lastIndex];
            }

            result.Reverse();

            Console.WriteLine("Maximum pairs connected: {0}", result.Count);
            Console.Write("Connected pairs: ");
            for (int i = 0; i < result.Count; i++)
            {
                Console.Write(south[result[i]] + " ");
            }

            Console.WriteLine();
        }
    }
}
