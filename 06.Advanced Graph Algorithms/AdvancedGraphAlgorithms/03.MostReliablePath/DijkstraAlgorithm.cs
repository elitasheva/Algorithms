namespace _03.MostReliablePath
{
    using System;
    using System.Collections.Generic;

    public class DijkstraAlgorithm
    {
        public static List<Node> Dijkstra(Dictionary<Node, Dictionary<Node, int>> graph,
            Node sourceNode, Node destinationNode)
        {
            Node[] prev = new Node[graph.Count];
            bool[] visited = new bool[graph.Count];
            PriorityQueue<Node> queue = new PriorityQueue<Node>();

            sourceNode.Reliability = 1;
            queue.Enqueue(sourceNode);

            while (queue.Count > 0)
            {
                var current = queue.ExtractMax();
                visited[current.Id] = true;

                if (current == destinationNode)
                {
                    break;
                }

                foreach (var node in graph[current])
                {
                    if (!visited[node.Key.Id])
                    {
                        queue.Enqueue(node.Key);
                        visited[node.Key.Id] = true;
                    }

                    var a = node.Value;
                    var newReliability = (current.Reliability) * (node.Value / 100.0);
                    if (newReliability > (node.Key.Reliability))
                    {
                        node.Key.Reliability = newReliability;
                        prev[node.Key.Id] = current;
                        queue.DecreaseKey(node.Key);
                    }
                }
            }

            if (double.IsInfinity(destinationNode.Reliability))
            {
                return null;
            }

            List<Node> path = new List<Node>();
            var currentNode = destinationNode;
            while (currentNode != null)
            {
                path.Add(currentNode);
                currentNode = prev[currentNode.Id];
            }

            path.Reverse();
            return path;
        }
    }
}
