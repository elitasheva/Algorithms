namespace _05.CombinationsWithoutRepetition
{
    using System;

    public class CombinationsWithoutRepetition
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] array = new int[k];
            int start = 1;
            int end = n;
            FindCombination(array,0,start,end);

        }

        private static void FindCombination(int[] array, int index, int start, int end)
        {
            if (index >= array.Length)
            {
                Console.WriteLine("(" + string.Join(" ",array) + ")");
            }
            else
            {
                for (int i = start; i <= end; i++)
                {
                    array[index] = i;
                    FindCombination(array,index+1,i+1,end);
                }
            }
        }
    }
}
