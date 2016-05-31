namespace _02.ModifiedKruskalAlgorithm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ModifiedKruskalAlgorithm
    {
        public static void Main(string[] args)
        {
            List<Edge> edges = new List<Edge>();
            int countOfNodes = int.Parse(Console.ReadLine().Split(':')[1]);
            int countOfEdges = int.Parse(Console.ReadLine().Split(':')[1]);
            ReadInput(edges, countOfEdges);
            var minimumSpanningForest = KruskalAlgorithm.Kruskal(countOfNodes, edges);

            Console.WriteLine("Minimum spanning forest weight: " +
                            minimumSpanningForest.Sum(e => e.Weight));

            foreach (var edge in minimumSpanningForest)
            {
                Console.WriteLine(edge);
            }
        }

        private static void ReadInput(List<Edge> edges,int countOfEdges)
        {
            for (int i = 0; i < countOfEdges; i++)
            {
                int[] data = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                Edge currentEdge = new Edge(data[0], data[1], data[2]);
                edges.Add(currentEdge);
            } 
        }
    }
}
