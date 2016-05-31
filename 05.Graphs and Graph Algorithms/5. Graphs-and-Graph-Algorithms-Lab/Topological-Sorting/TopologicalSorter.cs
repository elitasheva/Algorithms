using System;
using System.Collections.Generic;
using System.Linq;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
    }

    public ICollection<string> TopSort()
    {
        var predecessors = new Dictionary<string, int>();
        foreach (var node in this.graph)
        {
            if (!predecessors.ContainsKey(node.Key))
            {
                predecessors.Add(node.Key, 0);
            }
            foreach (var child in node.Value)
            {
                if (!predecessors.ContainsKey(child))
                {
                    predecessors.Add(child, 0);
                }
                predecessors[child]++;
            }

        }

        var result = new List<string>();
        while (true)
        {
            var currentNode = this.graph.Keys.FirstOrDefault(a => predecessors[a] == 0);
            if (currentNode == null)
            {
                  break;
            }
            result.Add(currentNode);
            
            foreach (var child in this.graph[currentNode])
            {
                predecessors[child]--;
            }
            this.graph.Remove(currentNode);
        }

        if (this.graph.Count > 0)
        {
            throw new InvalidOperationException("A cycle detected in the graph");
        }
        return result;
    }
}
