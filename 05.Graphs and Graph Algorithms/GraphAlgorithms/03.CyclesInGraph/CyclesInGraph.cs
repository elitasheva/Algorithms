namespace _03.CyclesInGraph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CyclesInGraph
    {
        private static Dictionary<string, List<string>> graph;

        public static void Main(string[] args)
        {
            ReadGraph();
            var predecessors = new Dictionary<string, int>();

            foreach (var node in graph)
            {
                if (!predecessors.ContainsKey(node.Key))
                {
                    predecessors.Add(node.Key, 0);
                }
                foreach (var child in node.Value)
                {
                    if (!predecessors.ContainsKey(child))
                    {
                        predecessors.Add(child, 0);
                    }
                    predecessors[child]++;
                }
            }

            
            while (true)
            {
                var current = graph.Keys.FirstOrDefault(a => predecessors[a] <= 1);
                if (current == null)
                {
                    break;
                }

                foreach (var child in graph[current])
                {
                    predecessors[child]--;
                }

                graph.Remove(current);
            }

            if (graph.Count > 0)
            {
                Console.WriteLine("Acyclic: No");
            }
            else
            {
                Console.WriteLine("Acyclic: Yes");
            }

        }

        private static void ReadGraph()
        {
            string input = Console.ReadLine();
            graph = new Dictionary<string, List<string>>();
            while (input != string.Empty)
            {
                string[] data = input.Split(new[] { '-', }, StringSplitOptions.RemoveEmptyEntries);
                string parent = data[0].Trim();
                string child = data[1].Trim();
                if (!graph.ContainsKey(parent))
                {
                    graph.Add(parent, new List<string>());
                }

                if (!graph.ContainsKey(child))
                {
                    graph.Add(child, new List<string>());
                }

                graph[parent].Add(child);
                graph[child].Add(parent);

                input = Console.ReadLine();
            }

        }

    }
}
