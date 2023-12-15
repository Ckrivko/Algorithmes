using SomeGraphs;
using System;
using System.Text;


namespace GraphsTraversals
{
    public class Program
    {
        static void Main(string[] args)
        {
            var graphAsDictionary = new SomeGraphs.Graphs().GraphAsDictionary;

            var visited = new HashSet<int>();
            var sb = new StringBuilder();

            var firstNode = graphAsDictionary.Take(1).First().Key;

             var dfsResult = DFS(graphAsDictionary, firstNode, visited, sb);
            var bfsRezult = BFS(graphAsDictionary, visited, sb, firstNode);
            var dfsasStackResult = DFSAsStack(graphAsDictionary,  visited,sb,firstNode);

            //  Console.WriteLine(dfsResult);
           // Console.WriteLine(bfsRezult);
            Console.WriteLine( dfsasStackResult);

        }

        private static string DFSAsStack(Dictionary<int, List<int>> graphAsDictionary, HashSet<int> visited, StringBuilder sb, int firstNode)
        {
            var stack = new Stack<int>();

            stack.Push(firstNode);

            while (stack.Count > 0)
            {

                var currNode = stack.Pop();
                if (!visited.Contains(currNode))
                {
                    sb.Append(currNode + " ");
                    visited.Add(currNode);

                }

                foreach (var node in graphAsDictionary[currNode])
                {
                    if (!visited.Contains(node))
                    {
                        stack.Push(node);

                    }
                }
            }

            return sb.ToString().TrimEnd();
        }



        private static string BFS(Dictionary<int, List<int>> graphAsDictionary, HashSet<int> visited, StringBuilder sb, int firstNode)
        {
            var queue = new Queue<int>();

            queue.Enqueue(firstNode);

            while (queue.Count > 0)
            {

                var currNode = queue.Dequeue();
                if (!visited.Contains(currNode))
                {
                    sb.Append(currNode + " ");
                    visited.Add(currNode);

                }

                foreach (var node in graphAsDictionary[currNode])
                {
                    if (!visited.Contains(node))
                    {
                        queue.Enqueue(node);

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
            return sb.ToString();
        }


    }
}