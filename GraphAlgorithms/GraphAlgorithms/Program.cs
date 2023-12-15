using System;

namespace GraphAlgorithms
{
    public class Program
    {
        class Edge
        {
            public int Parent { get; set; }
            public int Child { get; set; }
        }


        static void Main(string[] args)
        {

            var graphAsList = new List<int>[] {
                new List<int> { 3, 6},
                new List<int> { 2, 3, 4, 5, 6},
                new List<int> { 1, 4, 5},
                new List<int> { 0, 1, 5},
                new List<int> { 1, 2, 6},
                new List<int> { 1, 2, 3},
                new List<int> { 0, 1, 4}
                };

            // Add an edge { 3 <-> 6 }
            graphAsList[3].Add(6); 
            graphAsList[6].Add(3);
            // List the children of node #1
            var childNodesOfList = graphAsList[1];

            int[][] graphAsMatrix = new int[][] {
                   // 0 1 2 3 4 5 6
                  new int[]  { 0, 0, 0, 1, 0, 0, 1 }, // node 0
                  new int[]  { 0, 0, 1, 1, 1, 1, 1 }, // node 1
                  new int[]  { 0, 1, 0, 0, 1, 1, 0 }, // node 2      
                  new int[]  { 1, 1, 0, 0, 0, 1, 0 }, // node 3
                  new int[]  { 0, 1, 1, 0, 0, 0, 1 }, // node 4
                  new int[]  { 0, 1, 1, 1, 0, 0, 0 }, // node 5
                  new int[]  { 1, 1, 0, 0, 1, 0, 0 }, // node 6
                };

            // Add an edge { 3 -> 6 }
            graphAsMatrix[3][6] = 1;
            graphAsMatrix[6][3] = 1;
            // List the children of node #1
            int[] childNodesOfMatrix = graphAsMatrix[1];



            var graphAsEdge = new List<Edge>() {
            new Edge() { Parent = 0, Child = 3 },
            new Edge() { Parent = 0, Child = 6 },
            };

            // Add an edge { 3 -> 6 }
            graphAsEdge.Add(new Edge() { Parent = 3, Child = 6 });
            // List the children of node #1
            var childNodesOfEdge = graphAsEdge.Where(e => e.Parent == 1);
        }

    }
}