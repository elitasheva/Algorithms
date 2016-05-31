using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex
{
    class RecursiveArraySum
    {
        static void Main(string[] args)
        {
            int[] arr = new[] {2, 3, 4, 5};

            long sum = FindSum(arr);
            Console.WriteLine(sum);
        }

        static long FindSum(int[] arr, int index = 0)
        {
            if (index == arr.Length - 1)
            {
                return arr[arr.Length - 1];
            }
            return arr[index] + FindSum(arr, index + 1);
        }
    }
}
