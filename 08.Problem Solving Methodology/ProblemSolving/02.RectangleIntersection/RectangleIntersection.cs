namespace _02.RectangleIntersection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    public class RectangleIntersection
    {
        public static void Main(string[] args)
        {
            int numberOfRectangles = int.Parse(Console.ReadLine());
            List<Rectangle> rectangles = ReadInput(numberOfRectangles);

            var overlapping = FindOverlappingRectangles(rectangles);
            BigInteger totalOverlappingAreaWithRepeating = overlapping.Sum(r => r.Area);
            
            var repeatingPartsOfArea = FindOverlappingRectangles(overlapping);
            
            var groupedRepeatingPartsOfArea = repeatingPartsOfArea.GroupBy(r => r).ToDictionary(r => r.Key, r => r.Count());
            BigInteger areaForSubtract = 0;
            foreach (var area in groupedRepeatingPartsOfArea)
            {
                areaForSubtract += area.Key.Area * (area.Value - 1);
            }

            BigInteger result = totalOverlappingAreaWithRepeating - areaForSubtract;

            Console.WriteLine(result);
        }

        private static List<Rectangle> FindOverlappingRectangles(List<Rectangle> rectangles)
        {
            List<Rectangle> overlapping = new List<Rectangle>();
            var sorted = rectangles.OrderBy(r => r.MinX).ThenBy(r => r.MaxY).ToList();
            int count = 0;
            for (int i = 0; i < rectangles.Count; i++)
            {
                for (int j = i + 1; j < rectangles.Count; j++)
                {
                    if (sorted[j].MinX > sorted[i].MaxX && sorted[j].MinY > sorted[i].MaxY)
                    {
                        break;
                    }

                    if (sorted[i].Intersects(sorted[j]))
                    {
                        count++;
                        int left = Math.Max(sorted[i].MinX, sorted[j].MinX);
                        int right = Math.Min(sorted[i].MaxX, sorted[j].MaxX);
                        int bottom = Math.Max(sorted[i].MinY, sorted[j].MinY);
                        int top = Math.Min(sorted[i].MaxY, sorted[j].MaxY);

                        overlapping.Add(new Rectangle(count, left, right, bottom, top));


                    }
                }
            }

            return overlapping;
        }

        private static List<Rectangle> ReadInput(int numberOfRectangles)
        {
            List<Rectangle> rectangles = new List<Rectangle>();
            for (int i = 1; i <= numberOfRectangles; i++)
            {
                int[] data = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int minX = data[0];
                int maxX = data[1];
                int minY = data[2];
                int maxY = data[3];
                Rectangle current = new Rectangle(i, minX, maxX, minY, maxY);
                rectangles.Add(current);
            }

            return rectangles;
        }
    }
}
