namespace _03.CombinationsWithRepetition
{
    using System;

    public class CombinationsWithRepetition
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] array = new int[k];
            int start = 1;
            int end = n;
            FindCombinations(array,0,start,end);
        }

        private static void FindCombinations(int[] array, int index, int start, int end)
        {
            if (index >= array.Length)
            {
                Console.WriteLine("(" + string.Join(" ", array) + ")");
            }
            else
            {
                for (int i = start; i <= end; i++)
                {
                    array[index] = i;
                    FindCombinations(array,index+1,i,end);
                }

                start++;
            }
        }
    }
}
