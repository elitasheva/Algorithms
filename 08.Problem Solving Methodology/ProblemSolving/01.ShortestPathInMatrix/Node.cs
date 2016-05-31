namespace _01.ShortestPathInMatrix
{
    using System;

    public class Node  : IComparable<Node>
    {
        public Node(int id, int value, int distanceFromStart = int.MaxValue)
        {
            this.Id = id;
            this.Value = value;
            this.DistanceFromStart = distanceFromStart;
        }

        public int Id { get; set; }

        public int Value { get; set; }

        public int DistanceFromStart { get; set; }

        public Node Previous { get; set; }

        public int CompareTo(Node other)
        {
            int compare = this.DistanceFromStart.CompareTo(other.DistanceFromStart);
            if (compare == 0)
            {
                compare = this.Id.CompareTo(other.Id);
            }
            return compare;
        }

        public override string ToString()
        {
            return string.Format("value:{0}; dis:{1}", this.Value, this.DistanceFromStart);
        }
    }
}
