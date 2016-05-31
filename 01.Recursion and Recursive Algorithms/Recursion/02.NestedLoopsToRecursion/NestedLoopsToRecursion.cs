namespace _02.NestedLoopsToRecursion
{
    using System;

    public class NestedLoopsToRecursion
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            int start = 1;
            int end = n;
            Combinations(array,0,start,end);

        }

        public static void Combinations(int[] array, int index, int start, int end)
        {
            if (index >= array.Length)
            {
                Console.WriteLine(string.Join(", ", array));
            }
            else
            {
                for (int i = start; i <= end; i++)
                {
                    array[index] = i;
                    Combinations(array, index + 1, start, end);
                }
            }


        }
    }
}
