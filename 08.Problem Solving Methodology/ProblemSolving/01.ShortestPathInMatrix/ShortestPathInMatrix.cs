namespace _01.ShortestPathInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    public class ShortestPathInMatrix
    {
        private static Dictionary<Node, List<Node>> graph = new Dictionary<Node, List<Node>>();
        
        public static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rows][];
            FillMatrix(matrix);
            BuildGraph(matrix, rows, cols);
            var sourceNode = graph.First().Key;
            var destinationNode = graph.Last().Key;
            var shortestPath = FindShortestPath(sourceNode, destinationNode);
            var length = shortestPath.Last().DistanceFromStart;
            Console.WriteLine("Length: " + length);
            Console.WriteLine("Path: " + string.Join(" ", shortestPath.Select(a => a.Value)));


        }

       
        private static List<Node> FindShortestPath(Node sourceNode, Node destinationNode)
        {
            HashSet<Node> visited = new HashSet<Node>();
            PriorityQueue<Node> queue = new PriorityQueue<Node>();

            sourceNode.DistanceFromStart = sourceNode.Value;
            queue.Enqueue(sourceNode);

            while (queue.Count > 0)
            {
                var currentNode = queue.ExtractMin();
                visited.Add(currentNode);

                if (currentNode == destinationNode)
                {
                    break;
                }

                foreach (var node in graph[currentNode])
                {
                    if (!visited.Contains(node))
                    {
                        queue.Enqueue(node);
                        visited.Add(node);
                    }

                    var newDistance = currentNode.DistanceFromStart + node.Value;
                    if (newDistance < node.DistanceFromStart)
                    {
                        node.DistanceFromStart = newDistance;
                        node.Previous = currentNode;
                        queue.DecreaseKey(node);
                    }
                }
            }

            List<Node> result = new List<Node>();
            
            var current = destinationNode;
            while (current != null)
            {
                result.Add(current);
                current = current.Previous;
            }
            result.Reverse();
            return result;

        }

        private static void BuildGraph(int[][] matrix, int rows, int cols)
        {
            Node[,] matrixOfnodes = new Node[rows, cols];

            int count = 0;
            for (int i = 0; i < matrixOfnodes.GetLength(0); i++)
            {
                for (int j = 0; j < matrixOfnodes.GetLength(1); j++)
                {
                    count++;
                    Node current = new Node(count, matrix[i][j]);
                    matrixOfnodes[i, j] = current;
                    graph.Add(current, new List<Node>());
                }
            }

            for (int i = 0; i < matrixOfnodes.GetLength(0); i++)
            {
                for (int j = 0; j < matrixOfnodes.GetLength(1); j++)
                {
                    var current = matrixOfnodes[i, j];

                    if (i > 0)
                    {
                        //upper
                        graph[current].Add(matrixOfnodes[i - 1, j]);
                    }

                    if (j > 0)
                    {
                        //left
                        graph[current].Add(matrixOfnodes[i, j - 1]);
                    }

                    if (i < matrix.Length - 1)
                    {
                        //down
                        graph[current].Add(matrixOfnodes[i + 1, j]);
                    }
                   
                    if (j < matrix[i].Length - 1)
                    {
                        //right
                        graph[current].Add(matrixOfnodes[i, j + 1]);
                    }

                }
            }


        }

        private static void FillMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            }
        }
    }
}
