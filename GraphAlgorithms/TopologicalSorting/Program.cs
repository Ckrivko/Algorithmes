using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

namespace TopologicalSorting
{
    internal class Program
    {
        private static Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        private static Dictionary<string, int> dependencies = new Dictionary<string, int>();
        private static LinkedList<string> sorted = new LinkedList<string>();
        private static HashSet<string> visited = new HashSet<string>();
        private static HashSet<string> cycles = new HashSet<string>();

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            ReadGraph(n);
            // ExtractDependencies();
            //  Print();          

            var hasCycled = false;

            foreach (var node in graph.Keys)
            {
                try
                {
                    DFS(node);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                    hasCycled= true;
                    break;
                }

            }           
            if (!hasCycled)
            {
                
                Console.WriteLine("Topological sorting: " + string.Join(", ", sorted));
            }
                        
           
        }

        private static void DFS(string node)
        {
            if (cycles.Contains(node))
            {
                throw new InvalidOperationException("Invalid topological sorting");
            }

            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);
            cycles.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            cycles.Remove(node);
            sorted.AddFirst(node);
        }

        private static void ReadGraph(int n)
        {
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .Select(a => a.Trim()).ToArray();
                var key = input[0];

                if (input.Length > 1)
                {
                    var childrenNodes = input[1].Split(",",StringSplitOptions.RemoveEmptyEntries).Select(a => a.Trim()).ToList();

                    graph[key] = childrenNodes;
                }
                else
                {
                    graph[key] = new List<string>();

                }
            }
        }

        private static void Print()
        {
            var result = new List<string>();

            while (dependencies.Count > 0)
            {
                var nodeToRemove = dependencies.FirstOrDefault(d => d.Value == 0).Key;

                if (nodeToRemove == null)
                {
                    break;
                }

                dependencies.Remove(nodeToRemove);
                result.Add(nodeToRemove);

                foreach (var child in graph[nodeToRemove])
                {
                    dependencies[child] -= 1;
                }
            }

            if (dependencies.Count == 0)
            {
                Console.WriteLine("Topological sorting: " + string.Join(", ", result));

            }

            else
            {
                Console.WriteLine("Invalid topological sorting");
            }
        }

        private static void ExtractDependencies()
        {
            foreach (var kvp in graph)
            {
                var node = kvp.Key;
                var children = kvp.Value;

                if (!dependencies.ContainsKey(node))
                {
                    dependencies[node] = 0;
                }

                foreach (var child in children)
                {

                    if (!dependencies.ContainsKey(child))
                    {
                        dependencies[child] = 1;
                    }

                    else
                    {
                        dependencies[child] += 1;
                    }
                }


            }
        }


    }
}