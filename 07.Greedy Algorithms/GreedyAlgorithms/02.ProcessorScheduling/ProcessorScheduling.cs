namespace _02.ProcessorScheduling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProcessorScheduling
    {
        public static void Main(string[] args)
        {
            int taskCount = int.Parse(Console.ReadLine().Split(':')[1]);
            List<Task> tasks = new List<Task>();
            int maxDeadLine = 0;
            for (int i = 1; i <= taskCount; i++)
            {
                string[] data = Console.ReadLine().Split('-');
                int value = int.Parse(data[0].Trim());
                int deadLine = int.Parse(data[1].Trim());
                Task newTask = new Task(i, value, deadLine);

                if (deadLine > maxDeadLine)
                {
                    maxDeadLine = deadLine;
                }

                tasks.Add(newTask);
            }

            PriorityQueue<Task> queue = new PriorityQueue<Task>();
            List<Task> result = new List<Task>();
            int maxValue = 0;
            for (int i = maxDeadLine; i > 0; i--)
            {
                var current = tasks.Where(t => t.TaskDeadLine == i).ToList();
                foreach (var task in current)
                {
                    queue.Enqueue(task);
                }

                var currentTask = queue.ExtractMax();
                maxValue += currentTask.TaskValue;
                result.Add(currentTask);
            }

            result.Reverse();
            var sorted = result.OrderBy(t => t.TaskDeadLine).ThenBy(a => -a.TaskValue).ToList();
            Console.WriteLine("Optimal schedule:  {0}", string.Join(" -> ", sorted.Select(a => a.TaskNumber)));
            Console.WriteLine("Total value: {0}", maxValue);
        }
    }
}
