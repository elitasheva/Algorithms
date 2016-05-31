using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ShortestPathsWithNegativeEdges
{
    public class ShortestPathsWithNegativeEdges
    {
        private static bool hasCycle = false;
        private static double shortestDistance = 0;

        public static void Main(string[] args)
        {
            int countOfNodes = int.Parse(Console.ReadLine().Split(':')[1]);
            string path = Console.ReadLine().Split(':')[1];
            int sourse = int.Parse(path.Split('-')[0]);
            int destination = int.Parse(path.Split('-')[1]);
            int countOfEdges = int.Parse(Console.ReadLine().Split(':')[1]);

            List<Edge> edges = new List<Edge>();
            ReadInput(edges, countOfEdges);

            var shortestPath = FindShortestPathBellmanFord(sourse, destination, countOfNodes, edges);
            if (hasCycle)
            {
                Console.WriteLine("Negative cycle detected: {0}", string.Join(" -> ", shortestPath));
            }
            else
            {
                Console.WriteLine("Distance [{0} -> {1}]: {2}", sourse, destination, shortestDistance);
                Console.WriteLine("Path: {0}", string.Join(" -> ", shortestPath));
            }
            
        }

        private static List<int> FindShortestPathBellmanFord(int sourse, int destination, int countOfNodes, List<Edge> edges)
        {
            double[] distances = new double[countOfNodes];
            int[] prev = new int[countOfNodes];

            for (int i = 0; i < countOfNodes; i++)
            {
                distances[i] = double.PositiveInfinity;
            }

            distances[sourse] = 0;
            prev[sourse] = -1;
            for (int i = 0; i < countOfNodes - 1; i++)
            {
                foreach (var edge in edges)
                {
                    if (distances[edge.Start] + edge.Distance < distances[edge.End])
                    {
                        distances[edge.End] = distances[edge.Start] + edge.Distance;
                        prev[edge.End] = edge.Start;
                    }
                }
            }

            var path = new List<int>();

            foreach (var edge in edges)
            {
                if (distances[edge.Start] + edge.Distance < distances[edge.End])
                {
                    hasCycle = true;
                    int current = edge.Start;
                    path.Add(current);
                    while (true)
                    {
                        current = prev[current];
                        if (current == edge.Start)
                        {
                            break;
                        }
                        path.Add(current);
                    }

                }
            }
            if (!hasCycle)
            {
                var current = destination;
                while (current != -1)
                {
                    path.Add(current);
                    current = prev[current];
                }
            }
            path.Reverse();
            shortestDistance = distances[destination];
            return path;
        }

        private static void ReadInput(List<Edge> edges, int countOfEdges)
        {
            for (int i = 0; i < countOfEdges; i++)
            {
                string[] data = Console.ReadLine().Split(' ');
                int start = int.Parse(data[0]);
                int end = int.Parse(data[1]);
                double dist = double.Parse(data[2]);

                edges.Add(new Edge(start, end, dist));
            }
        }
    }
}
