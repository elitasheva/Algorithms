namespace _01.BinomialCoefficients
{
    using System;
  
    public class BinomialCoefficients
    {
        public static void Main(string[] args)
        {
            Console.Write("n: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("k: ");
            int k = int.Parse(Console.ReadLine());

            long[][] coeff = new long[n + 1][];
            long coefficient = FindBinomialCoefficient(n, k, coeff);
            Console.WriteLine("binomial coefficient: " + coefficient);
        }

        private static long FindBinomialCoefficient(int n, int k, long[][] coeff)
        {
            if (coeff[n] == null)
            {
                coeff[n] = new long[n + 1];
            }

            if (k > n)
            {
                return 0;
            }

            if (k == 0 || k == n)
            {
                return 1;
            }

            if (coeff[n][k] == 0)
            {
                coeff[n][k] = FindBinomialCoefficient(n - 1, k - 1, coeff) + FindBinomialCoefficient(n - 1, k, coeff);
            }

            return coeff[n][k];
        }
    }
}
