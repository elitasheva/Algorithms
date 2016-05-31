namespace _01.ExtendCableNetwork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;

    public class ExtendCableNetwork
    {
        private static BinaryHeap<Edge> priorityQueue = new BinaryHeap<Edge>();
        private static List<Edge> spanningTree = new List<Edge>();
        private static HashSet<int> connectedNodes = new HashSet<int>();
        private static decimal budget;

        public static void Main(string[] args)
        {
            budget = decimal.Parse(Console.ReadLine().Split(':')[1]);
            int countOfNodes = int.Parse(Console.ReadLine().Split(':')[1]);
            int countOfEdges = int.Parse(Console.ReadLine().Split(':')[1]);
            var graph = BuildGraph(countOfEdges);

            foreach (var node in connectedNodes.ToList())
            {
                foreach (var edge in graph[node])
                {
                    if (connectedNodes.Contains(edge.StartNode) ^ connectedNodes.Contains(edge.EndNode))
                    {
                        priorityQueue.Enqueue(edge);
                    }
                    
                }
            }

            Prim(graph);
            decimal total = 0;
            foreach (var edge in spanningTree)
            {
                total += edge.Weight;
                Console.WriteLine(edge);
            }
            Console.WriteLine("Budget used: " + total);
        }

        private static void Prim(Dictionary<int, List<Edge>> graph)
        {
            
            while (priorityQueue.Count > 0)
            {
                var smallestEdge = priorityQueue.ExtractMin();
                if (connectedNodes.Contains(smallestEdge.StartNode) ^ connectedNodes.Contains(smallestEdge.EndNode))
                {
                    if (budget - smallestEdge.Weight >= 0)
                    {
                        spanningTree.Add(smallestEdge);
                        budget -= smallestEdge.Weight;

                        var nonTreeNode = connectedNodes.Contains(smallestEdge.StartNode)
                       ? smallestEdge.EndNode
                       : smallestEdge.StartNode;

                        connectedNodes.Add(nonTreeNode);
                        foreach (var childEdge in graph[nonTreeNode])
                        {
                            priorityQueue.Enqueue(childEdge);
                        }
                    }
                }
            }
        }

        private static Dictionary<int, List<Edge>> BuildGraph(int countOfEdges)
        {
            var graph = new Dictionary<int, List<Edge>>();
            for (int i = 0; i < countOfEdges; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                int startNode = int.Parse(input[0]);
                int endNode = int.Parse(input[1]);
                int weight = int.Parse(input[2]);

                Edge currentEdge = new Edge(startNode, endNode, weight);

                if (!graph.ContainsKey(startNode))
                {
                    graph.Add(startNode, new List<Edge>());
                }
                graph[startNode].Add(currentEdge);

                if (!graph.ContainsKey(endNode))
                {
                    graph.Add(endNode, new List<Edge>());
                }
                graph[endNode].Add(currentEdge);

                if (input.Contains("connected"))
                {
                    connectedNodes.Add(startNode);
                    connectedNodes.Add(endNode);
                }
            }

            return graph;
        }
    }
}
