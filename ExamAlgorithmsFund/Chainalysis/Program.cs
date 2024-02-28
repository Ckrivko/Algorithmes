using System;
using System.Collections.Generic;


namespace Chainalysis
{
    internal class Program
    {

        private static Dictionary<string, HashSet<string>> graph = new Dictionary<string, HashSet<string>>();
        private static HashSet<string> visited = new HashSet<string>();

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                  

                var sender = input[0];
                var reciever = input[1];
                var amount = input[2];

                if (!graph.ContainsKey(sender))
                {
                    graph[sender] = new HashSet<string>();
                }

                if (!graph.ContainsKey(reciever))
                {
                    graph[reciever] = new HashSet<string>();
                }

                graph[sender].Add(reciever);
                graph[reciever].Add(sender);
            }

            var count = FindCountGroups();
            Console.WriteLine(count);

        }

        private static int FindCountGroups()
        {
            var count = 0;

            foreach (var node in graph.Keys)
            {
                if (!visited.Contains(node))
                {
                    DFS(node);
                    count++;
                }
            }

            return count;
        }

        private static void DFS(string node)
        {
            visited.Add(node);

            foreach (var child in graph[node])
            {
                if (!visited.Contains(child))
                {
                    DFS(child);
                }
            }
        }
    }
}