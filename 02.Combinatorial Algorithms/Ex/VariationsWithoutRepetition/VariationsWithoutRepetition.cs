using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariationsWithoutRepetition
{
    public class VariationsWithoutRepetition
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] array = new int[k];
            bool[] used = new bool[n + 1];
            GenerateVariations(array, n, used);

        }

        private static void GenerateVariations(int[] arrray, int sizeOfSet, bool[] used, int index = 0)
        {
            if (index >= arrray.Length)
            {
                PrintCombination(arrray);
            }
            else
            {

                for (int i = 1; i <= sizeOfSet; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        arrray[index] = i;
                        GenerateVariations(arrray, sizeOfSet, used, index + 1);
                        used[i] = false;
                    }
                }

            }

        }

        private static void PrintCombination(int[] arrray)
        {
            Console.WriteLine("(" + string.Join(", ", arrray) + ")");
        }
    }
}
