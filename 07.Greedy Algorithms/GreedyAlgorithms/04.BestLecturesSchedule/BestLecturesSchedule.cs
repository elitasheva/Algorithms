namespace _04.BestLecturesSchedule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BestLecturesSchedule
    {
        public static void Main(string[] args)
        {
            int countOfLectures = int.Parse(Console.ReadLine().Split(':')[1]);
            List<Lecture> lectures = new List<Lecture>();

            for (int i = 0; i < countOfLectures; i++)
            {
                string[] data = Console.ReadLine().Split(':');
                int start = int.Parse(data[1].Split('-')[0]);
                int end = int.Parse(data[1].Split('-')[1]);
                Lecture lecture = new Lecture(data[0], start, end);
                lectures.Add(lecture);
            }

            List<Lecture> result = new List<Lecture>();
            var sorted = lectures.OrderBy(l => l.End).ToList();
            int index = 0;
            while (sorted.Count > 0)
            {
                var current = sorted[index];
                result.Add(current);
                sorted.RemoveAll(l => l.Start < current.End);
            }

            Console.WriteLine("Lectures ({0}):", result.Count);
            foreach (var lecture in result)
            {
                Console.WriteLine(lecture);
            }

        }
    }
}
