namespace _05.BreakCycles
{
    using System;
    public class Edge : IComparable<Edge>
    {   
        public string Start { get; set; }
        public string End { get; set; }

        public int CompareTo(Edge other)
        {
            int compare = this.Start.CompareTo(other.Start);
            if (compare == 0)
            {
                compare = this.End.CompareTo(other.End);
            }

            return compare;
        }

        public override bool Equals(object obj)
        {
            var toCompare = obj as Edge;
            if (toCompare == null)
            {
                return false;
            }

            return this.Start == toCompare.Start && this.End == toCompare.End;
        }
    }
}