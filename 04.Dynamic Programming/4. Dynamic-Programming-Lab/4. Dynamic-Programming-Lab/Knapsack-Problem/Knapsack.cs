namespace Knapsack_Problem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Knapsack
    {
        public static void Main()
        {
            var items = new[]
            {
                new Item {Weight = 5, Price = 30},
                new Item {Weight = 8, Price = 120},
                new Item {Weight = 7, Price = 10},
                new Item {Weight = 0, Price = 20},
                new Item {Weight = 4, Price = 50},
                new Item {Weight = 5, Price = 80},
                new Item {Weight = 2, Price = 10}
            };

            var knapsackCapacity = 20;

            var itemsTaken = FillKnapsack(items, knapsackCapacity);

            Console.WriteLine("Knapsack weight capacity: {0}", knapsackCapacity);
            Console.WriteLine("Take the following items in the knapsack:");
            foreach (var item in itemsTaken)
            {
                Console.WriteLine(
                    "  (weight: {0}, price: {1})",
                    item.Weight,
                    item.Price);
            }

            Console.WriteLine("Total weight: {0}", itemsTaken.Sum(i => i.Weight));
            Console.WriteLine("Total price: {0}", itemsTaken.Sum(i => i.Price));
        }

        public static Item[] FillKnapsack(Item[] items, int capacity)
        {
            int[,] maxPrice = new int[items.Length, capacity + 1];
            bool[,] isTaken = new bool[items.Length, capacity + 1];

            for (int i = 0; i <= capacity; i++)
            {
                if (items[0].Weight <= i)
                {
                    maxPrice[0, i] = items[0].Price;
                    isTaken[0, i] = true;
                }
            }

            for (int i = 1; i < items.Length; i++)
            {
                for (int j = 0; j <= capacity; j++)
                {
                    maxPrice[i, j] = maxPrice[i - 1, j];
                    var remainingCapacity = j - items[i].Weight;
                    if (remainingCapacity >= 0 && items[i].Price + maxPrice[i-1, remainingCapacity] > maxPrice[i, j])
                    {
                        maxPrice[i, j] += items[i].Price;
                        isTaken[i, j] = true;
                    }
                }
            }

            var itemTaken = new List<Item>();
            int itemIndex = items.Length - 1;

            while (itemIndex >= 0)
            {
                if (isTaken[itemIndex, capacity])
                {
                    itemTaken.Add(items[itemIndex]);
                    capacity = capacity - items[itemIndex].Weight;
                }

                itemIndex--;
            }

           // itemTaken.Reverse();
           return itemTaken.ToArray();
        }
    }

}
