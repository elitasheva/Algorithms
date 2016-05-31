namespace _03.RectangleIntersection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RectangleIntersection
    {
        private static List<Rectangle> rectangles = new List<Rectangle>();
        private static List<int> coordX = new List<int>();
        private static List<int> coordY = new List<int>();

        public static void Main(string[] args)
        {
            int numberOfRectangles = int.Parse(Console.ReadLine());
            ReadInput(numberOfRectangles);
            int totalArea = 0;

            for (int x = 0; x < coordX.Count - 1; x++)
            {
                for (int y = 0; y < coordY.Count - 1; y++)
                {
                    int overlap = 0;
                    foreach (var rectangle in rectangles)
                    {
                        if (rectangle.MinX < coordX[x + 1] &&
                            coordX[x] < rectangle.MaxX &&
                            rectangle.MinY < coordY[y + 1] &&
                            coordY[y] < rectangle.MaxY)
                        {
                            overlap++;
                        }
                    }
                    if (overlap >= 2)
                    {
                        totalArea += Math.Abs(coordX[x] - coordX[x + 1]) * Math.Abs(coordY[y] - coordY[y + 1]);
                    }
                }
            }

            Console.WriteLine(totalArea);
        }

        private static void ReadInput(int numberOfRectangles)
        {
            for (int i = 1; i <= numberOfRectangles; i++)
            {
                int[] data = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int minX = data[0];
                int maxX = data[1];
                int minY = data[2];
                int maxY = data[3];
                Rectangle current = new Rectangle(i, minX, maxX, minY, maxY);
                rectangles.Add(current);
                coordX.Add(minX);
                coordX.Add(maxX);
                coordY.Add(minY);
                coordY.Add(maxY);
            }

            coordX = coordX.Distinct().OrderBy(x => x).ToList();
            coordY = coordY.Distinct().OrderBy(y => y).ToList();

        }
    }
}
