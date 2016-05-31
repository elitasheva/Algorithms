namespace Kurskal
{
    using System;
    using System.Collections.Generic;

    public class KruskalAlgorithm
    {
        public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
        {
            edges.Sort();
            var parents = new int[numberOfVertices];
            var spanningTree = new List<Edge>();
            for (int i = 0; i < numberOfVertices; i++)
            {
                parents[i] = i;
            }

            foreach (var edge in edges)
            {
                var start = FindRoot(edge.StartNode, parents);
                var end = FindRoot(edge.EndNode, parents);
                if (start != end)
                {
                    spanningTree.Add(edge);
                    parents[start] = end;
                }
            }

            return spanningTree;
        }

        public static int FindRoot(int node, int[] parents)
        {
            var root = node;
            while (parents[root] != root)
            {
                root = parents[root];
            }

            while (root != node)
            {
                var oldNode = parents[node];
                parents[node] = root;
                node = oldNode;
            }

            return root;
        }
    }
}
