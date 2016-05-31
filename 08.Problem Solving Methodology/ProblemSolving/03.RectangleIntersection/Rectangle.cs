namespace _03.RectangleIntersection
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

       
        public override string ToString()
        {
            return this.Id.ToString();
        }
    }
}
