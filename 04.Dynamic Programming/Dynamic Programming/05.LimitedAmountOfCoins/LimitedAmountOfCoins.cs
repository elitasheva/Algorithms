namespace _05.LimitedAmountOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LimitedAmountOfCoins
    {
        private static int[] nums;
        private static HashSet<string> combinations = new HashSet<string>();
        private static int sum = 0;

        public static void Main(string[] args)
        {
            string[] data1 = Console.ReadLine().Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
            sum = int.Parse(data1[1]);
            string[] data2 = Console.ReadLine().Split(new[] { '=', '}', '{' }, StringSplitOptions.RemoveEmptyEntries);
            nums = data2[2].Split(',').Select(int.Parse).ToArray();

            for (int i = 1; i <= nums.Length; i++)
            {
                int[] arr = new int[i];
                FindCombination(arr, 0, 0, nums.Length);
            }

            Console.WriteLine(combinations.Count);
        }

        private static void FindCombination(int[] arr, int index, int start, int end)
        {
            if (index >= arr.Length)
            {
                if (arr.Sum() == sum)
                {
                    string comb = string.Join(", ", arr);
                    combinations.Add(comb);
                }
            }
            else
            {
                for (int i = start; i < end; i++)
                {
                    arr[index] = nums[i];
                    FindCombination(arr, index + 1, i + 1, end);
                }

                start++;

            }
        }
    }
}
