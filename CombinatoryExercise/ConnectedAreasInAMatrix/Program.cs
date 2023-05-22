using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConnectedAreasInAMatrix
{
    public class Area
    {
        public Area(int row, int col, int size)
        {
            Row = row;
            Col = col;
            Size = size;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public int Size { get; set; }

    }



    public class Program
    {
        private static char[,] matrix;
        private static bool[,] used;
        private static int size = 0;

        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];
            used = new bool[rows, cols];
            var sb = new StringBuilder();

            var areas = new List<Area>();

            for (int r = 0; r < rows; r++)
            {
                var colElements = Console.ReadLine();

                for (int c = 0; c < cols; c++)
                {

                    matrix[r, c] = colElements[c];
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    {
                        size = 0;
                        ExploreArea(row, col);
                        if (size > 0)
                        {
                            areas.Add(new Area(row, col, size));
                        }

                    }
                }
            }

            areas = areas
                .OrderByDescending(x=>x.Size)
                .ThenBy(x=>x.Row)
                .ThenBy(x=>x.Col)
                .ToList();

            sb.AppendLine($"Total areas found: {areas.Count}");
            var count = 1;
           
            if (areas.Count > 0)
            {
                foreach (var area in areas)
                {
                    sb.AppendLine($"Area #{count} at ({area.Row}, {area.Col}), size: {area.Size}");
                    count++;
                }

            }
            Console.WriteLine(sb.ToString().Trim());
        }

        private static void ExploreArea(int row, int col)
        {
            if (row < 0
                || row >= matrix.GetLength(0)
                || col < 0
                || col >= matrix.GetLength(1)
                || matrix[row, col] == '*'
                || used[row, col])
            {
                return;
            }
            size += 1;

            used[row, col] = true;

            ExploreArea(row + 1, col);
            ExploreArea(row - 1, col);
            ExploreArea(row, col + 1);
            ExploreArea(row, col - 1);


        }
    }
}
