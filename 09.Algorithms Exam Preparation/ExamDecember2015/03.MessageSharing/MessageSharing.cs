namespace _03.MessageSharing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MessageSharing
    {
        private static Dictionary<string, List<string>> connections = new Dictionary<string, List<string>>();
        private static List<string> allPeople;
        private static int[] levels;
        private static bool[] visited;
        private static Queue<string> queue = new Queue<string>();

        public static void Main(string[] args)
        {
            ReadInput();
            levels = new int[allPeople.Count];

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                foreach (var child in connections[current])
                {
                    int index = allPeople.IndexOf(child);
                    if (!visited[index])
                    {
                        visited[index] = true;
                        levels[index] = levels[allPeople.IndexOf(current)] + 1;
                        queue.Enqueue(child);
                    }
                }

            }

            List<string> unreachable = new List<string>();
            for (int i = 0; i < visited.Length; i++)
            {
                if (!visited[i])
                {
                    unreachable.Add(allPeople[i]);
                }
            }

            if (unreachable.Count > 0)
            {
                unreachable.Sort();
                Console.WriteLine("Cannot reach: {0}", string.Join(", ", unreachable));
            }
            else
            {
                int maxLevel = levels.Max();
                Console.WriteLine("All people reached in {0} steps", maxLevel);
                List<string> peopleAtLastLevel = new List<string>();
                for (int i = 0; i < levels.Length; i++)
                {
                    if (levels[i] == maxLevel)
                    {
                        peopleAtLastLevel.Add(allPeople[i]);
                    }
                }

                peopleAtLastLevel.Sort();
                Console.WriteLine("People at last step: {0}", string.Join(", ", peopleAtLastLevel));
            }
        }

        private static void ReadInput()
        {
            allPeople = Console.ReadLine().Split(':')[1].Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string[] connected = Console.ReadLine().Split(':')[1].Split(new[] { ',' },
                StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < connected.Length; i++)
            {
                string[] data = connected[i].Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                string humanA = data[0].Trim();
                string humanB = data[1].Trim();

                if (!connections.ContainsKey(humanA))
                {
                    connections.Add(humanA, new List<string>());
                }
                connections[humanA].Add(humanB);

                if (!connections.ContainsKey(humanB))
                {
                    connections.Add(humanB, new List<string>());
                }
                connections[humanB].Add(humanA);

            }
            visited = new bool[allPeople.Count];
            string[] start = Console.ReadLine().Split(':')[1].Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < start.Length; i++)
            {
                queue.Enqueue(start[i]);
                int index = allPeople.IndexOf(start[i]);
                visited[index] = true;
                if (!connections.ContainsKey(start[i]))
                {
                    connections.Add(start[i], new List<string>());
                }
            }
        }
    }
}
