namespace _02.GeneratePermutationsIteratively
{
    using System;
    using System.Linq;

    public class GeneratePermutationsIteratively
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = Enumerable.Range(1,n).ToArray();
            int[] array2 = Enumerable.Range(0, n + 1).ToArray();

            int count = 0;
            PrintPermutation(array);
            count++;

            int index = 1;
            while (index < n)
            {
                array2[index]--;
                int temp = 0;
                if (index % 2 != 0)
                {
                    temp = array2[index];
                }

                Swap(ref array[temp], ref array[index]);
                index = 1;
                while (array2[index] == 0)
                {
                    array2[index] = index;
                    index++;
                }

                PrintPermutation(array);
                count++;
            }

            Console.WriteLine("Total permutations: {0}", count);

           
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
