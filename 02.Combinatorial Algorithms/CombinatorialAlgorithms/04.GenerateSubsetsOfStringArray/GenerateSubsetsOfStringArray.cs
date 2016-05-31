namespace _04.GenerateSubsetsOfStringArray
{
    using System;
    using System.Linq;

    public class GenerateSubsetsOfStringArray
    {
        static string[] set = new[] { "test", "rock", "fun" };
        private static string[] subset;

        public static void Main(string[] args)
        {
            
            int k = 2;
            subset = new string[k];
            GenerateSubset(0,0);
        }

        private static void GenerateSubset(int start, int index)
        {
            if (index >= subset.Length)
            {
                PrintSubset(subset);
            }
            else
            {
                for (int i = start; i < set.Length; i++)
                {
                    subset[index] = set[i];
                    GenerateSubset(i+1,index + 1);
                }
               
            }
        }

        private static void PrintSubset(string[] subset)
        {
            Console.WriteLine("(" + string.Join(" ", subset) + ")");
        }
    }
}
