namespace _03.MostReliablePath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MostReliablePath
    {
        public static void Main(string[] args)
        {
            Dictionary<Node, Dictionary<Node, int>> graph = new Dictionary<Node, Dictionary<Node, int>>();
            Dictionary<int, Node> nodes = new Dictionary<int, Node>();
            int countOfNodes = int.Parse(Console.ReadLine().Split(':')[1]);
            string path = Console.ReadLine().Split(':')[1];
            int sourse = int.Parse(path.Split('-')[0]);
            int destination = int.Parse(path.Split('-')[1]);
            int countOfEdges = int.Parse(Console.ReadLine().Split(':')[1]);
            BuildGraph(graph, nodes, countOfEdges);

            Node sourceNode = nodes[sourse];
            Node destinationNode = nodes[destination];
            var mostReliablePath = DijkstraAlgorithm.Dijkstra(graph, sourceNode, destinationNode);

            var reliability = mostReliablePath[mostReliablePath.Count - 1].Reliability * 100;
            Console.WriteLine("Most reliable path reliability: {0}%", Math.Round(reliability, 2));
            Console.WriteLine(string.Join(" -> ", mostReliablePath.Select(node => node.Id)));

        }

        private static void BuildGraph(Dictionary<Node, Dictionary<Node, int>> graph, Dictionary<int, Node> nodes, int countOfEdges)
        {
            for (int i = 0; i < countOfEdges; i++)
            {
                int[] data = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                Node parent = new Node(data[0]);
                Node child = new Node(data[1]);

                if (!nodes.ContainsKey(data[0]))
                {
                    nodes.Add(data[0], parent);
                    graph.Add(parent, new Dictionary<Node, int>());
                }
                else
                {
                    parent = nodes[data[0]];
                }

                if (!nodes.ContainsKey(data[1]))
                {
                    nodes.Add(data[1], child);
                    graph.Add(child, new Dictionary<Node, int>());
                }
                else
                {
                    child = nodes[data[1]];
                }

                graph[parent].Add(child, data[2]);

                graph[child].Add(parent, data[2]);
            }
        }
    }
}
