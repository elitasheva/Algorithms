namespace _01.SequencesOfLimitedSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SequencesOfLimitedSum
    {
        private static List<int> sequence = new List<int>();
        private static StringBuilder result = new StringBuilder();
        private static int currentSum = 0;

        public static void Main(string[] args)
        {
            int s = int.Parse(Console.ReadLine());

            FindSequence(s);
            Console.WriteLine(result.ToString().Trim());

        }

        private static void FindSequence(int sum)
        {
            if (currentSum > sum)
            {
                return;
            }

            if (sequence.Count > 0)
            {
                PrintResult();
            }

            for (int j = 1; j <= sum; j++)
            {
                sequence.Add(j);
                currentSum += j;
                FindSequence(sum);
                sequence.RemoveAt(sequence.Count - 1);
                currentSum -= j;
            }
        }

        private static void PrintResult()
        {
            result.AppendLine(string.Join(" ", sequence));
        }
    }
}
