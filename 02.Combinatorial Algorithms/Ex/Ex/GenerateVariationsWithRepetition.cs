using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex
{
    public class GenerateVariationsWithRepetition
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] array = new int[2];

            GenerateVariations(array, n);
        }

        private static void GenerateVariations(int[] array, int sizeOfSet, int index=0)
        {
            if (index >= array.Length)
            {
                PrintCombination(array);
            }
            else
            {
                for (int i = 1; i <= sizeOfSet; i++)
                {
                    array[index] = i;
                    GenerateVariations(array,sizeOfSet,index+1);
                }
            }
        }

        private static void PrintCombination(int[] array)
        {
            Console.WriteLine("(" + string.Join(", ",array) + ")");
        }
    }
}
