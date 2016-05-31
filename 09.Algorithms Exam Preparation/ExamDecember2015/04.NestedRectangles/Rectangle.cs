namespace _04.NestedRectangles
{
    using System;
    using System.Collections.Generic;

    public class Rectangle
    {
        public Rectangle(string name, int startX, int endX, int startY, int endY)
        {
            this.Name = name;
            this.StartX = startX;
            this.EndX = endX;
            this.StartY = startY;
            this.EndY = endY;
            this.Area = Math.Abs(this.EndX - this.StartX) * Math.Abs(this.EndY - this.StartY);
            this.InsideRectangles = new List<Rectangle>();
        }

        public string Name { get; set; }

        public int StartX { get; set; }

        public int EndX { get; set; }

        public int StartY { get; set; }

        public int EndY { get; set; }

        public int Level { get; set; }

        public long Area { get; set; }

        public Rectangle Prev { get; set; }

        public List<Rectangle> InsideRectangles { get; set; }

        public bool IsInside(Rectangle other)
        {
            return this.StartX >= other.StartX &&
                   this.EndX <= other.EndX &&
                   this.StartY >= other.StartY &&
                   this.EndY <= other.EndY;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
