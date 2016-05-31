namespace _05.BreakCycles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class BreakCycles
    {
        private static bool hasPath;

        public static void Main(string[] args)
        {
            var graph = ReadGraph();
            var result = BreakGraph(graph);
            PrintResult(result);
        }

        private static void PrintResult(List<Edge> result)
        {
            Console.WriteLine("Edgeds to remove: {0}", result.Count);
            result.ForEach(e => Console.WriteLine("{0} – {1}", e.Start, e.End));
        }

        private static List<Edge> BreakGraph(Dictionary<string, List<string>> graph)
        {
            var removedEdges = new List<Edge>();
            var edges = EnumerateEdges(graph);
            foreach (var edge in edges)
            {
                hasPath = false;
                graph[edge.Start].Remove(edge.End);
                CheckForPath(graph, edge.Start, edge.End, new HashSet<string>());

                if (!hasPath)
                {
                      graph[edge.Start].Add(edge.End);
                }
                else if (edge.Start.CompareTo(edge.End) < 0)
                {
                     removedEdges.Add(edge);
                }
            }
            return removedEdges;
        }

        private static void CheckForPath(Dictionary<string, List<string>> graph,
            string start, string end, HashSet<string> visited)
        {
            if (start.CompareTo(end) == 0)
            {
                hasPath = true;
                return;
            }

            if (!visited.Contains(start))
            {
                visited.Add(start);
                graph[start].ForEach(child => CheckForPath(graph, child, end, visited));
            }
        }

        private static List<Edge> EnumerateEdges(Dictionary<string, List<string>> graph)
        {
            return (from node in graph.Keys
                    from child in graph[node]
                    select new Edge() { Start = node, End = child })
                .OrderBy(e => e).ToList();



        }

        private static Dictionary<string, List<string>> ReadGraph()
        {
            var graph = new Dictionary<string, List<string>>();
            var input = Console.ReadLine();
            while (input != string.Empty)
            {
                var data = input.Split(new[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                var parent = data[0].Trim();
                var children = data[1].Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                graph.Add(parent, children);

                input = Console.ReadLine();
            }

            return graph;
        }
    }
}
