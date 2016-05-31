namespace AStarAlgorithm
{
    using System;
    using System.Collections.Generic;

    public class AStar
    {
        private readonly PriorityQueue<Node> openNodesByFCost;
        private readonly HashSet<Node> closedSet;
        private readonly Node[,] graph;
        private readonly char[,] map;

        public AStar(char[,] map)
        {
            this.map = map;
            this.graph = new Node[map.GetLength(0), map.GetLength(1)];
            this.closedSet = new HashSet<Node>();
            this.openNodesByFCost = new PriorityQueue<Node>();
        }

        public List<int[]> FindShortestPath(int[] startCoords, int[] endCoords)
        {
            var startNode = GetNode(startCoords[0], startCoords[1]);
            startNode.GCost = 0;
            this.openNodesByFCost.Enqueue(startNode);

            while (this.openNodesByFCost.Count > 0)
            {
                var currentNode = this.openNodesByFCost.ExtractMin();
                this.closedSet.Add(currentNode);

                if (currentNode.Row == endCoords[0] && currentNode.Col == endCoords[1])
                {
                    return ReconstructPath(currentNode);
                }

                var neighbours = this.GetNeighbours(currentNode);

                foreach (var neighbour in neighbours)
                {
                    if (this.closedSet.Contains(neighbour))
                    {
                        continue;
                    }

                    var gCost = currentNode.GCost + CalculateGCost(currentNode, neighbour);
                    if (gCost < neighbour.GCost)
                    {
                        neighbour.GCost = gCost;
                        neighbour.Parent = currentNode;

                        if (!this.openNodesByFCost.Contains(neighbour))
                        {
                            neighbour.HCost = CalculateHCost(neighbour, endCoords);
                            this.openNodesByFCost.Enqueue(neighbour);
                        }
                        else
                        {
                            this.openNodesByFCost.DecreaseKey(neighbour);
                        }
                    }
                }
            }

            //var end = GetNode(endCoords[0], endCoords[1]);
            //var shortestPath = ReconstructPath();
            return new List<int[]>(0);
        }

        private List<int[]> ReconstructPath(Node node)
        {
            var cells = new List<int[]>();
            while (node != null)
            {
                cells.Add(new[] { node.Row, node.Col });
                node = node.Parent;
            }

            return cells;
        }

        private int CalculateHCost(Node neighbour, int[] endCoords)
        {
            return GetDistance(neighbour.Row, neighbour.Col, endCoords[0], endCoords[1]);
        }

        private int CalculateGCost(Node currentNode, Node neighbour)
        {
            return GetDistance(currentNode.Row, currentNode.Col, neighbour.Row, neighbour.Col);
        }

        private int GetDistance(int row1, int col1, int row2, int col2)
        {
            var deltaX = Math.Abs(col1 - col2);
            var deltaY = Math.Abs(row1 - row2);

            if (deltaX > deltaY)
            {
                return 14 * deltaY + 10 * (deltaX - deltaY);
            }

            return 14 * deltaX + 10 * (deltaY - deltaX);
        }

        private List<Node> GetNeighbours(Node currentNode)
        {
            var neighbours = new List<Node>();

            var maxRow = this.graph.GetLength(0);
            var maxCol = this.graph.GetLength(1);

            for (int row = currentNode.Row - 1; row <= currentNode.Row + 1 && row < maxRow; row++)
            {
                if (row < 0)
                {
                    continue;
                }
                for (int col = currentNode.Col - 1; col <= currentNode.Col + 1 && col < maxCol; col++)
                {
                    if (col >= 0 && this.map[row, col] != 'W')
                    {
                        if (row == currentNode.Row && col == currentNode.Col)
                        {
                             continue;
                        }
                        var neighbour = GetNode(row, col);
                        neighbours.Add(neighbour);
                    }
                }
            }

            return neighbours;
        }

        private Node GetNode(int row, int col)
        {
            return this.graph[row, col] ?? (this.graph[row, col] = new Node(row, col));
        }
    }
}
