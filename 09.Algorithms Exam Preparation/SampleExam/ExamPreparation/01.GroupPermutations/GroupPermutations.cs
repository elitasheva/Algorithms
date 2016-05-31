using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.GroupPermutations
{
    public class GroupPermutations
    {
        private static Dictionary<char, int> groupedData;
        private static StringBuilder sb = new StringBuilder();

        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            groupedData = input.GroupBy(a => a).ToDictionary(gr => gr.Key, gr => gr.Count());

            var allKeys = groupedData.Keys.ToArray();

            GeneratePermutations(allKeys, 0);
            Console.WriteLine(sb.ToString().Trim());

        }

        private static void GeneratePermutations(char[] array, int index)
        {
            if (index >= array.Length - 1)
            {
                PrintPermutation(array);
            }
            else
            {
                for (int i = index; i < array.Length; i++)
                {
                    Swap(ref array[index], ref array[i]);
                    GeneratePermutations(array, index + 1);
                    Swap(ref array[index], ref array[i]);
                }
            }
        }

        private static void Swap(ref char current, ref char next)
        {
            char temp = current;
            current = next;
            next = temp;
        }

        private static void PrintPermutation(char[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                char currentChar = array[i];
                for (int j = 0; j < groupedData[currentChar]; j++)
                {
                    sb.Append(currentChar);
                }

            }
            sb.AppendLine();
        }
    }
}
