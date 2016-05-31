namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumOfCoins
    {
        public static void Main(string[] args)
        {
            var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
            var targetSum = 923;

            var selectedCoins = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            var sortedCoins = coins.OrderByDescending(c => c).ToList();

            var chosenCoins = new Dictionary<int,int>();
            int currentSum = 0;
            int coinIndex = 0;

            while (coinIndex < sortedCoins.Count && currentSum != targetSum)
            {
                var currentCoinValue = sortedCoins[coinIndex];
                var remainingSum = targetSum - currentSum;
                var numberOfCoins = remainingSum / currentCoinValue;

                if (numberOfCoins > 0)
                {
                    chosenCoins.Add(currentCoinValue, numberOfCoins);
                    currentSum += currentCoinValue * numberOfCoins;
                }

                coinIndex++;
            }

            if (currentSum != targetSum)
            {
                 throw new InvalidOperationException();
            }
            return chosenCoins;
        }
    }
}