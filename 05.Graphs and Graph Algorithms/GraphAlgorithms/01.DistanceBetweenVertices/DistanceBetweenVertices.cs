namespace _01.DistanceBetweenVertices
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Design;
    using System.Linq;

    public class DistanceBetweenVertices
    {
        private static Dictionary<int, List<int>> graph;
        private static HashSet<int> visited;
        private static Queue<Node> queue;
        public static void Main(string[] args)
        {
            graph = ReadGraph();
            string input = Console.ReadLine();
            while (input != string.Empty)
            {
                int[] data = input.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int len = BFS(data[0], data[1]);
                Console.WriteLine("{{{0}, {1}}} -> {2}", data[0], data[1], len);
                input = Console.ReadLine();
            }
        }

        private static int BFS(int start, int end)
        {
            queue = new Queue<Node>();
            queue.Enqueue(new Node() { Value = start, Distance = 0 });
            visited = new HashSet<int>();
            visited.Add(start);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                
                if (current.Value == end)
                {
                    return current.Distance;
                }
                foreach (var vertex in graph[current.Value])
                {
                    if (!visited.Contains(vertex))
                    {
                        queue.Enqueue(new Node() { Value = vertex, Distance = current.Distance+1 });
                        visited.Add(vertex);
                    }
                   
                }
            }

            return - 1;
        }

        private static Dictionary<int, List<int>> ReadGraph()
        {
            string input = Console.ReadLine();
            graph = new Dictionary<int, List<int>>();
            while (input != string.Empty)
            {
                string[] data = input.Split(new[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                int parent = int.Parse(data[0]);
                List<int> children = new List<int>();
                if (data.Length > 1)
                {
                    children = data[1].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                }
                graph.Add(parent, children);
                input = Console.ReadLine();
            }

            return graph;
        }
    }
}
