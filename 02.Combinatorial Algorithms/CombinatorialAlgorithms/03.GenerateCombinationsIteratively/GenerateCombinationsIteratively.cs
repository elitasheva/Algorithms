namespace _03.GenerateCombinationsIteratively
{
    using System;
    using System.Collections.Generic;

    public class GenerateCombinationsIteratively
    {
        public static void Main(string[] args)
        {
            int n = 3;
            int k = 2;

            int[] comb = new int[2];
            Stack<int> stack = new Stack<int>();
            stack.Push(1);

            while (stack.Count > 0)
            {
                int index = stack.Count - 1;
                int value = stack.Pop();

                while (value <= n)
                {
                    comb[index] = value;
                    index++;
                    value++;
                    stack.Push(value);

                    if (index==k)
                    {
                        Console.WriteLine(string.Join(", ",comb));
                        break;
                    }
                }
            }

        }
    }
}
