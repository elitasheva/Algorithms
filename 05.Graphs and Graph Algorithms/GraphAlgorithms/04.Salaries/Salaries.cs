using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Salaries
{
    public class Salaries
    {
        private static List<int>[] data;
         
        public static void Main(string[] args)
        {
            ReadData();
            var salaries = new Dictionary<int, decimal>();
            for (int i = 0; i < data.Length; i++)
            {
                CalculateSalaries(salaries, i);
            }

            decimal sum = salaries.Values.Sum();
            Console.WriteLine(sum);
        }

        private static void CalculateSalaries(Dictionary<int, decimal> salaries, int i)
        {
            if (!salaries.ContainsKey(i))
            {
                salaries.Add(i, 0);

                if (data[i].Count > 0)
                {
                    foreach (var emp in data[i])
                    {
                        CalculateSalaries(salaries, emp);
                        salaries[i] += salaries[emp];
                    }
                }
                else
                {
                    salaries[i]++;
                }
            }
            
        }

        private static void ReadData()
        {
            int n = int.Parse(Console.ReadLine());
            data = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                data[i] = new List<int>();
                string input = Console.ReadLine();
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == 'Y')
                    {
                          data[i].Add(j);
                    }
                }
            }
            
        }
    }
}
