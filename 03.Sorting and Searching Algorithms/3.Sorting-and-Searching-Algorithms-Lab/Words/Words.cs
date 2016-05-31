namespace Words
{
    using System;
    using System.Collections.Generic;
   
    public class Words
    {
        private static long count = 0;
       
        public static void Main(string[] args)
        {
            string inputWord = Console.ReadLine();
            char[] word = inputWord.ToCharArray();
            FindPermutation(word, 0);
           
            Console.WriteLine(count);
        }

        private static void FindPermutation(char[] word, int index)
        {
            if (index >= word.Length - 1)
            {
               if (Check(word))
                {
                    count++;
                }
            }
            else
            {
                HashSet<int> set = new HashSet<int>();
                for (int i = index; i < word.Length; i++)
                {
                    if (!set.Contains(word[i]))
                    {
                        Swap(word, index, i);
                        FindPermutation(word, index + 1);
                        Swap(word, index, i);
                        set.Add(word[i]);
                    }
                }
            }
        }

        private static bool Check(char[] word)
        {
            char currentSymbol = word[0];
            for (int i = 1; i < word.Length; i++)
            {
                char nextSymbol = word[i];
                if (currentSymbol == nextSymbol)
                {
                    return false;
                }
                currentSymbol = word[i];
            }

            return true;
        }

        private static void Swap(char[] word, int indexCurrent, int indexNext)
        {
            char temp = word[indexCurrent];
            word[indexCurrent] = word[indexNext];
            word[indexNext] = temp;
        }
    }
}
