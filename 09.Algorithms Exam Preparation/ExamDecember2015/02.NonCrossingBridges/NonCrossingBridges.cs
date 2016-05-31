namespace _02.NonCrossingBridges
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class NonCrossingBridges
    {
        private static List<int> indeces = new List<int>();
        public static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int lastIndex = 0;
            for (int i = 0; i < sequence.Length; i++)
            {
                for (int j = lastIndex; j < i; j++)
                {
                    if (sequence[i] == sequence[j])
                    {
                        lastIndex = i;
                        indeces.Add(j);
                        indeces.Add(i);

                    }
                }
            }

            if (indeces.Count == 0)
            {
                Console.WriteLine("No bridges found");
            }
            else if (indeces.Count == 2)
            {
                Console.WriteLine("1 bridge found");
            }
            else
            {
                int count = indeces.Count / 2;
                Console.WriteLine("{0} bridges found", count);
            }

            string[] result = new string('X', sequence.Length).ToCharArray().Select(ch => ch.ToString()).ToArray();
            for (int i = 0; i < indeces.Count; i++)
            {
                result[indeces[i]] = sequence[indeces[i]].ToString();
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
