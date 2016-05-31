namespace _04.ShortestPathsBetweenAllNodes
{
    using System;
    using System.Linq;

    public class ShortestPathsBetweenAllNodes
    {
        const double Inf = double.PositiveInfinity;

        public static void Main(string[] args)
        {
            int countOfNodes = int.Parse(Console.ReadLine().Split(':')[1]);
            int countOfEdges = int.Parse(Console.ReadLine().Split(':')[1]);

            double[,] matrix = new double[countOfNodes, countOfNodes];
            ReadInput(matrix, countOfEdges);

            var dist = matrix.Clone() as double[,];

            for (int k = 0; k < countOfNodes; k++)
            {
                for (int i = 0; i < countOfNodes; i++)
                {
                    for (int j = 0; j < countOfNodes; j++)
                    {
                        if (dist[i, k] + dist[k, j] < dist[i, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                        }
                    }
                }

            }
            Console.WriteLine("Shortest paths matrix:");
            Console.WriteLine(new string('-', countOfNodes*2));
            PrintMatrix(dist);
        }

        private static void PrintMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void ReadInput(double[,] matrix, int countOfEdges)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        matrix[i, j] = 0;
                    }
                    else
                    {
                        matrix[i, j] = Inf;
                    }
                }
            }

            for (int i = 0; i < countOfEdges; i++)
            {
                int[] data = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                matrix[data[0], data[1]] = data[2];
                matrix[data[1], data[0]] = data[2];
            }
        }
    }
}
