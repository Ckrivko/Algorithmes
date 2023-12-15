using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace ConnectedComponents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var graph = new Dictionary<int, List<int>>();
            var sb = new StringBuilder();
            var visited = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                var arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x)).ToList();

                if (arr.Count > 0)
                {
                    graph[i] = arr;
                }
                else
                {
                    graph[i] = new List<int>();
                }

            }            

            var resultArr = new HashSet<string>();

            foreach (var node in graph.Keys)
            {
                var result = DFS(graph, node, visited, sb).Trim();
              //  var result = BFS(graph, node, visited, sb).Trim();

                if (result.Length > 0)
                {

                    resultArr.Add(result);
                }

                sb.Clear();
            }

            foreach (var component in resultArr)
            {
                Console.WriteLine($"Connected component: {string.Join(" ", component)}");
            }
        }

        private static string BFS(Dictionary<int, List<int>> graph, int node,
              HashSet<int> visited,
           StringBuilder sb)
        {

            var queue = new Queue<int>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                var currNode = queue.Dequeue();

                if (!visited.Contains(currNode))
                {
                    sb.Append(currNode + " ");
                    visited.Add(currNode);
                }

                foreach (var childNode in graph[currNode])
                {

                    if (!visited.Contains(childNode))
                    {
                        visited.Add(childNode);
                        queue.Enqueue(childNode);
                        sb.Append(childNode + " ");
                    }
                }

            }

            return sb.ToString().TrimEnd();
        }

        private static string DFS(Dictionary<int, List<int>> graph, int node
           , HashSet<int> visited,
           StringBuilder sb)
        {

            if (visited.Contains(node))
            {
                return sb.ToString();
            }

            visited.Add(node);

            foreach (var child in graph[node])
            {

                DFS(graph, child, visited, sb);
            }

            sb.Append(node + " ");
            return sb.ToString().TrimEnd();
        }
    }
}