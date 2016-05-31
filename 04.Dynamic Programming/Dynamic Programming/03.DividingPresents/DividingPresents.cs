namespace _03.DividingPresents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DividingPresents
    {
        public static void Main(string[] args)
        {
            int[] gifts = Console.ReadLine()
             .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse)
             .ToArray();

            int capacity = gifts.Sum(a => a) / 2;

            var giftTaken = TakeTheGifts(gifts,capacity);
            
            int firstSum = giftTaken.Sum();
            int secondSum = gifts.Sum() - firstSum;
            int diff = Math.Abs(firstSum - secondSum);
            Console.WriteLine("Difference: " + diff);
            Console.WriteLine("Alan:{0} Bob:{1}", firstSum, secondSum);
            Console.WriteLine("Alan takes:" + string.Join(", ", giftTaken));
            Console.WriteLine("Bob takes the rest.");
        }

        private static List<int> TakeTheGifts(int[] gifts, int capacity)
        {
            var max = new int[gifts.Length, capacity + 1];
            var isTaken = new bool[gifts.Length, capacity + 1];

            for (int c = 0; c <= capacity; c++)
            {
                if (gifts[0] <= c)
                {
                    max[0, c] = gifts[0];
                    isTaken[0, c] = true;
                }
            }

            for (int i = 1; i < gifts.Length; i++)
            {
                for (int c = 0; c <= capacity; c++)
                {
                    max[i, c] = max[i - 1, c];
                    int left = c - gifts[i];

                    if (left > 0 && max[i-1,left] + gifts[i] > max[i-1,c])
                    {
                        max[i, c] = max[i - 1, left] + gifts[i];
                        isTaken[i, c] = true;
                    }
                }
            }

            var itemTaken = new List<int>();
            var itemIndex = gifts.Length - 1;

            while (itemIndex >= 0)
            {
                if (isTaken[itemIndex,capacity])
                {
                     itemTaken.Add(gifts[itemIndex]);
                    capacity -= gifts[itemIndex];
                }

                itemIndex--;
            }

            //itemTaken.Reverse();
            return itemTaken;
        }
    }
}
