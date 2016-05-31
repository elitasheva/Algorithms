namespace Dijkstra
{
    using System;
    using System.Collections.Generic;

    public static class DijkstraWithPriorityQueue
    {
        public static List<int> DijkstraAlgorithm(Dictionary<Node, Dictionary<Node, int>> graph,
            Node sourceNode, Node destinationNode)
        {
            int?[] prev = new int?[graph.Count];
            bool[] visited = new bool[graph.Count];
            PriorityQueue<Node> queue = new PriorityQueue<Node>();

            //foreach (var node in graph)
            //{
            //    node.Key.DistanceFromStart = double.PositiveInfinity;
            //}

            sourceNode.DistanceFromStart = 0;
            queue.Enqueue(sourceNode);

            while (queue.Count > 0)
            {
                var currentNode = queue.ExtractMin();
                visited[currentNode.Id] = true;

                if (currentNode == destinationNode)
                {
                    break;
                }

                foreach (var node in graph[currentNode])
                {
                    if (!visited[node.Key.Id])
                    {
                        queue.Enqueue(node.Key);
                        visited[node.Key.Id] = true;
                    }

                    var newDistance = currentNode.DistanceFromStart + node.Value;
                    if (newDistance < node.Key.DistanceFromStart)
                    {
                        node.Key.DistanceFromStart = newDistance;
                        prev[node.Key.Id] = currentNode.Id;
                        queue.DecreaseKey(node.Key);
                    }
                }
            }

            if (double.IsInfinity(destinationNode.DistanceFromStart))
            {
                return null;
            }

            List<int> path = new List<int>();
            int? current = destinationNode.Id;
            while (current != null)
            {
                path.Add(current.Value);
                current = prev[current.Value];
            }

            path.Reverse();
            return path;
        }
    }
}
