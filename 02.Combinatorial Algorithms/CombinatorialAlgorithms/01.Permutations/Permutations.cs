namespace _01.Permutations
{
    using System;

    public class Permutations
    {
        private static int countOfPermutations = 0;

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            for (int i = 1; i <= n; i++)
            {
                array[i - 1] = i;
            }

            GeneraratePermutation(array, 0);
            Console.WriteLine("Total permutations: " + countOfPermutations);
        }

        private static void GeneraratePermutation(int[] array, int index)
        {
            if (index >= array.Length - 1)
            {
                PrintPermutation(array);
                countOfPermutations++;
            }
            else
            {
                
                for (int i = index; i < array.Length; i++)
                {
                    Swap(ref array[index], ref array[i]);
                    GeneraratePermutation(array, index + 1);
                    Swap(ref array[index],ref array[i]);
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
            Console.WriteLine(string.Join(", ", array));
        }
    }
}
