namespace _03.MostReliablePath
{
    using System;

    public class Node  : IComparable<Node>
    {
        public Node(int id, double reliability = double.NegativeInfinity)
        {
            this.Id = id;
            this.Reliability = reliability;
        }
        public int Id { get; set; }

        public double Reliability { get; set; }

        public int CompareTo(Node other)
        {
            return this.Reliability.CompareTo(other.Reliability);
        }

        public override string ToString()
        {
            return string.Format("id: {0} w: {1}", this.Id, this.Reliability);
        }
    }
}
