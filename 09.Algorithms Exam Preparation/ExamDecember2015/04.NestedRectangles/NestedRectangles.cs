namespace _04.NestedRectangles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NestedRectangles
    {
        private static List<Rectangle> rectangles = new List<Rectangle>();

        public static void Main(string[] args)
        {
            ReadInput();
            rectangles = rectangles.OrderByDescending(r => r.Area).ToList();

            Rectangle best = null;
            foreach (var rectangle in rectangles)
            {
                FindNestedRectangles(rectangle);
                if (best == null || best.Level < rectangle.Level ||
                        (best.Level == rectangle.Level && rectangle.Name.CompareTo(best.Name) < 0))
                {
                    best = rectangle;
                }

            }

            List<string> result = new List<string>();
            while (best != null)
            {
                result.Add(best.Name);
                best = best.Prev;
            }

            Console.WriteLine(string.Join(" < ", result));
        }

        private static void FindNestedRectangles(Rectangle current)
        {
            if (current.Level > 0)
            {
                return;
            }

            Rectangle best = null;
            current.Level = 1;
            foreach (var rectangle in rectangles)
            {
                if (current != rectangle && rectangle.IsInside(current))
                {
                    FindNestedRectangles(rectangle);
                    if (best == null || best.Level < rectangle.Level ||
                        (best.Level == rectangle.Level && rectangle.Name.CompareTo(best.Name) < 0))
                    {
                        best = rectangle;
                    }

                }
            }

            if (best != null)
            {
                current.Level = best.Level + 1;
                current.Prev = best;
            }
        }

        private static void ReadInput()
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] data = input.Split(':');
                string name = data[0];
                int[] coords = data[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int startX = coords[0];
                int endX = coords[2];
                int startY = coords[3];
                int endY = coords[1];
                Rectangle rect = new Rectangle(name, startX, endX, startY, endY);
                rectangles.Add(rect);
                input = Console.ReadLine();
            }
        }
    }
}
