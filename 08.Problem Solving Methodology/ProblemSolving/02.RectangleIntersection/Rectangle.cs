namespace _02.RectangleIntersection
{
    using System;

    public class Rectangle
    {
        public Rectangle(int id, int minX, int maxX, int minY, int maxY)
        {
            this.Id = id;
            this.MinX = minX;
            this.MaxX = maxX;
            this.MinY = minY;
            this.MaxY = maxY;
            this.Area = Math.Abs((this.MinX - this.MaxX) * (this.MinY - this.MaxY));
        }

        public int Id { get; set; }

        public int MinX { get; set; }

        public int MaxX { get; set; }

        public int MinY { get; set; }

        public int MaxY { get; set; }

        public long Area { get; set; }

        public bool Intersects(Rectangle other)
        {
            return this.MinX < other.MaxX &&
                   other.MinX < this.MaxX &&
                   this.MinY < other.MaxY &&
                   other.MinY < this.MaxY;
        }

        public override bool Equals(object obj)
        {
            Rectangle other = obj as Rectangle;
            return this.MinX == other.MinX &&
                this.MaxX == other.MaxX &&
                this.MinY == other.MinY &&
                   this.MaxY == other.MaxY;
        }

        public override int GetHashCode()
        {
            return this.MinX.GetHashCode() +
                this.MaxX.GetHashCode() +
                this.MinY.GetHashCode() +
                this.MaxY.GetHashCode();
        }

        public override string ToString()
        {
            return this.Id.ToString();
        }
    }
}
