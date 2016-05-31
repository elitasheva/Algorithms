namespace _04.UnlimitedAmountOfCoins
{
    using System;
    using System.Linq;

    public class UnlimitedAmountOfCoins
    {
        private static int[] nums;
        private static int countOfCombinations = 0;
        private static int sum = 0;

        public static void Main(string[] args)
        {
            string[] data1 = Console.ReadLine().Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
            sum = int.Parse(data1[1]);
            string[] data2 = Console.ReadLine().Split(new[] { '=', '}', '{' }, StringSplitOptions.RemoveEmptyEntries);
            nums = data2[2].Split(',').Select(int.Parse).ToArray();

            int m = nums.Length;
           Console.WriteLine(Count(nums, m, sum));  

        }

        private static long Count(int[] arr, int m, int sum)
        {
            var memo = new long[sum + 1];
            memo[0] = 1;
            for (int i = 0; i < m; i++)
            {
                for (int j = arr[i]; j <= sum; j++)
                {
                    memo[j] += memo[j - arr[i]];
                }
            }

            return memo[sum];
        }

    }
}
