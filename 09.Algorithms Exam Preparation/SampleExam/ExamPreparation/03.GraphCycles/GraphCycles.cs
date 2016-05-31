namespace _03.GraphCycles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GraphCycles
    {
        private static List<int>[] graph;
        private static bool[,] hasEdge;

        public static void Main(string[] args)
        {
            int countOfNodes = int.Parse(Console.ReadLine());
            hasEdge = new bool[countOfNodes, countOfNodes];
            graph = new List<int>[countOfNodes];
            ReadInput(countOfNodes);
            DetectCycles();
        }

        private static void DetectCycles()
        {
            int count = 0;
            for (int first = 0; first < graph.Length; first++)
            {
                foreach (var second in graph[first])
                {
                    if (second > first)
                    {
                        foreach (var third in graph[second])
                        {
                            if (third > first && second != third)
                            {
                                if (hasEdge[third,first])
                                {
                                    count++;
                                    Console.WriteLine("{{{0} -> {1} -> {2}}}", first, second, third);
                                }
                            }
                        }
                    }
                }
            }
            if (count == 0)
            {
                Console.WriteLine("No cycles found"); 
            }

        }

        private static void ReadInput(int countOfNodes)
        {
            for (int i = 0; i < countOfNodes; i++)
            {
                string[] data = Console.ReadLine().Split(new[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                int parentValue = int.Parse(data[0]);
                if (data.Length < 2)
                {
                    graph[parentValue] = new List<int>();
                }
                else
                {
                    var children = data[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                    graph[parentValue] = new List<int>();
                    for (int j = 0; j < children.Count; j++)
                    {
                        graph[parentValue].Add(children[j]);
                        hasEdge[parentValue, children[j]] = true;
                    }

                    graph[parentValue] = graph[parentValue].Distinct().OrderBy(p => p).ToList();

                }

            }
        }
    }
}
