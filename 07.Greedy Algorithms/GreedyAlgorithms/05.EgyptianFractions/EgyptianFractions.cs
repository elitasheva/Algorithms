namespace _05.EgyptianFractions
{
    using System;
    using System.Collections.Generic;

    public class EgyptianFractions
    {
        private static List<string> fractions = new List<string>();

        public static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split('/');
            long numerator = long.Parse(data[0]);
            long denominator = long.Parse(data[1]);

            FindEgyptianFractions(numerator, denominator);

            if (fractions.Count > 0)
            {
                Console.WriteLine("{0}/{1} = {2}", numerator, denominator, string.Join(" + ", fractions));
            }
        }

        private static void FindEgyptianFractions(long numerator, long denominator)
        {
            if (numerator == 0 || denominator == 0)
            {
                return;
            }

            if (denominator % numerator == 0)
            {
                fractions.Add(string.Format("1/{0}", denominator / numerator));
                return;
            }

            if (numerator % denominator == 0)
            {
                return;
            }

            if (numerator > denominator)
            {
                Console.WriteLine("Error (fraction is equal to or greater than 1)");
                return;
            }

            long n = (denominator / numerator) + 1;
            fractions.Add(string.Format("1/{0}", n));
            FindEgyptianFractions(numerator * n - denominator, denominator * n);
        }
    }
}
