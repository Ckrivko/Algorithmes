namespace SomeGraphs
{
    public class Graphs
    {
        public Graphs()
        {
            this.GraphsAsList = new List<int>[] {
                new List<int> { 3, 6},
                new List<int> { 2, 3, 4, 5, 6},
                new List<int> { 1, 4, 5},
                new List<int> { 0, 1, 5},
                new List<int> { 1, 2, 6},
                new List<int> { 1, 2, 3},
                new List<int> { 0, 1, 4}
                };

            this.GraphAsMatrix = new int[][] {
                   // 0 1 2 3 4 5 6
                  new int[]  { 0, 0, 0, 1, 0, 0, 1 }, // node 0
                  new int[]  { 0, 0, 1, 1, 1, 1, 1 }, // node 1
                  new int[]  { 0, 1, 0, 0, 1, 1, 0 }, // node 2      
                  new int[]  { 1, 1, 0, 0, 0, 1, 0 }, // node 3
                  new int[]  { 0, 1, 1, 0, 0, 0, 1 }, // node 4
                  new int[]  { 0, 1, 1, 1, 0, 0, 0 }, // node 5
                  new int[]  { 1, 1, 0, 0, 1, 0, 0 }, // node 6
                };

            this.GraphAsDictionary = new Dictionary<int, List<int>>
            {
                { 1,new List<int>{19,21,14 } },
                { 19,new List<int>{7,12,31,21 } },
                { 7,new List<int>{ 1} },
                { 31,new List<int>{ 21} },
                { 21,new List<int>{14 } },
                 { 14,new List<int>{23,6 } },
                { 23,new List<int>{ 21} },
                { 12,new List<int>()},
                { 6,new List<int>() }

            };
        }


        public new List<int>[] GraphsAsList { get; set; }


        public int[][] GraphAsMatrix { get; set; }

        public Dictionary<int, List<int>> GraphAsDictionary { get; set; }
    }
}