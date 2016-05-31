namespace _01.ReverseArray
{
    using System;
    using System.Linq;

    public class ReverseArray
    {
        public static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Reverse(array);
            Console.WriteLine();
        }

        public static void Reverse(int[] array, int index = 0)
        {
            if (index == array.Length)
            {
                return;
            }

            Reverse(array,index+1);
            Console.Write(array[index] + " ");
        }
    }
}
