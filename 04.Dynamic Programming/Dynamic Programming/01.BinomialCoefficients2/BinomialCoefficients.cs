namespace _01.BinomialCoefficients2
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

            var firstRow = new int[n+1];
            var seconRow = new int[n+1];
            firstRow[0] = 1;
            seconRow[0] = 1;
            seconRow[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 1; j < i; j++)
                    {
                        firstRow[j] = seconRow[j - 1] + seconRow[j];
                    }

                    firstRow[i] = 1;
                }
                else
                {
                    for (int j = 1; j < i; j++)
                    {
                        seconRow[j] = firstRow[j - 1] + firstRow[j];
                    }

                    seconRow[i] = 1;
                }
            }

            if (n % 2 == 0)
            {
                Console.WriteLine(firstRow[k]);
            }
            else
            {
                Console.WriteLine(seconRow[k]);
            }


        }

    }
}
