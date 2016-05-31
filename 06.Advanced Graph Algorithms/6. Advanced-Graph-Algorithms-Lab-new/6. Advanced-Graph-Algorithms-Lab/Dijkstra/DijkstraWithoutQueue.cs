namespace Dijkstra
{
    using System;
    using System.Collections.Generic;

    public static class DijkstraWithoutQueue
    {
        public static List<int> DijkstraAlgorithm(int[,] graph, int sourceNode, int destinationNode)
        {
            int n = graph.GetLength(0);
            int[] distances = new int[n];
            for (int i = 0; i < n; i++)
            {
                distances[i] = int.MaxValue;
            }

            distances[sourceNode] = 0;

            var used = new bool[n];
            int?[] prev = new int?[n];

            while (true)
            {
                int minDistance = int.MaxValue;
                int minNode = 0;
                for (int node = 0; node < n; node++)
                {
                    if (!used[node] && distances[node] < minDistance)
                    {
                        minDistance = distances[node];
                        minNode = node;
                    }
                }

                if (minDistance == int.MaxValue)
                {
                     break;
                }

                used[minNode] = true;

                for (int i = 0; i < n; i++)
                {
                    if (graph[minNode, i] > 0)
                    {
                        int newDistance = distances[minNode] + graph[minNode, i];
                        if (newDistance < distances[i])
                        {
                            distances[i] = newDistance;
                            prev[i] = minNode;
                        }
                    }
                }
            }

            if (distances[destinationNode] == int.MaxValue)
            {
                return null;
            }

            var path = new List<int>();
            int? currentNode = destinationNode;
            while (currentNode != null)
            {
                path.Add(currentNode.Value);
                currentNode = prev[currentNode.Value];
            }

            path.Reverse();
            return path;
        }
    }
}
