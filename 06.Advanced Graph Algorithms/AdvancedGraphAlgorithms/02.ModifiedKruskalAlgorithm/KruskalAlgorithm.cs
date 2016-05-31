namespace _02.ModifiedKruskalAlgorithm
{
    using System.Collections.Generic;

    public class KruskalAlgorithm
    {
        public static List<Edge> Kruskal(int numberOfnodes, List<Edge> edges)
        {
            edges.Sort();
            var parents = new int[numberOfnodes];
            for (int i = 0; i < numberOfnodes; i++)
            {
                parents[i] = i;
            }

            var spanningTree = new List<Edge>();
            foreach (var edge in edges)
            {
                var currentStartNode = FindRoot(edge.StartNode, parents);
                var currentEndNode = FindRoot(edge.EndNode, parents);
                if (currentStartNode != currentEndNode)
                {
                     spanningTree.Add(edge);
                    parents[currentStartNode] = currentEndNode;
                }

            }

            return spanningTree;
        }

        private static int FindRoot(int node, int[] parents)
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
