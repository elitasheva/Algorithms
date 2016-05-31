namespace _05.PermutationsWithRepetition
{
    using System;
    using System.Collections.Generic;

    public class PermutationsWithRepetition
    {
        public static void Main(string[] args)
        {
            //int[] array = { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            int[] array = { 1, 1, 5, 5, 5 };
            //int[] array = {1, 3, 5, 5};
            GeneratePermutation(array, 0);
        }

        private static void GeneratePermutation(int[] array, int index)
        {
            if (index >= array.Length - 1)
            {
                PrintPermutation(array);
            }
            else
            {
                HashSet<int> set = new HashSet<int>();

                for (int i = index; i < array.Length; i++)
                {
                    if (!set.Contains(array[i]))
                    {
                        Swap(ref array[index], ref array[i]);
                        GeneratePermutation(array, index + 1);
                        Swap(ref array[index], ref array[i]);
                        set.Add(array[i]);
                    }
                }
            }
        }

        private static void Swap(ref int current, ref int next)
        {
            int temp = current;
            current = next;
            next = temp;
        }

        private static void PrintPermutation(int[] array)
        {
            Console.WriteLine("{" + string.Join(", ", array) + "}");
        }
    }
}
