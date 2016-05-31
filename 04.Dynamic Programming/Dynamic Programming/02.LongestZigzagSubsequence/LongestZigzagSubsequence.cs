namespace _02.LongestZigzagSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LongestZigzagSubsequence
    {
        public static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine()
                .Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var longest = FindLongestZigzagSubsequence(sequence);
            Console.WriteLine("subsequence = [{0}]", string.Join(", ", longest));

        }

       
        private static List<int> FindLongestZigzagSubsequence(int[] sequence)
        {    
            int[] length = new int[sequence.Length];
            int[] prevIndex = new int[sequence.Length];
            int[] diff = new int[sequence.Length];
            int maxLength = 0;
            int lastIndex = -1;

            for (int i = 0; i < sequence.Length; i++)
            {
                length[i] = 1;
                prevIndex[i] = - 1;
                diff[i] = 0;

                for (int j = 0; j < i; j++)
                {
                    var currentDiff = sequence[i] - sequence[j];
                    bool isZigZag = (diff[j] > 0 && currentDiff < 0) || (diff[j] < 0 && currentDiff > 0);

                    if ((diff[j] == 0 || isZigZag) && length[j]+1 > length[i])
                    {
                        length[i] = length[j] + 1;
                        prevIndex[i] = j;
                        diff[i] = currentDiff;
                    }

                    if (length[i] > maxLength)
                    {
                        maxLength = length[i];
                        lastIndex = i;
                    }
                }
            }
            

            List<int> result = new List<int>();

            while (lastIndex != -1)
            {
                result.Add(sequence[lastIndex]);
                lastIndex = prevIndex[lastIndex];
            }

            result.Reverse();
            return result;
        }
    }
}
