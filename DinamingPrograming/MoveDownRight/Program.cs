using System;
using System.Collections.Generic;
using System.Linq;

namespace MoveDownRight
{
    internal class Program
    {
        private static int[,] matrix;
        private static bool[,] visited;
        private static List<string> path = new List<string>();
        private static int maxSum;

        static void Main(string[] args)
        {
            var row = int.Parse(Console.ReadLine());
            var col = int.Parse(Console.ReadLine());

            matrix = new int[row, col];
            visited = new bool[row, col];

            FillMatrix();

            var result = DinamingHghiestSum(row, col);
            result.Push($"[0, 0]");


            Console.WriteLine(string.Join(" ", result));
             //PrintMatrix();
            // var currpath = new List<string>();
            //  GetHighestSum(0, 0, 0, currpath);
            //   path.Add($"[{row - 1}, {col - 1}]");
            //  Console.WriteLine(string.Join(" ", path));
            // Console.WriteLine(maxSum);
        }

        private static Stack<string> DinamingHghiestSum(int rows, int cols)
        {
            var dp = new int[rows, cols];
            dp[0, 0] = matrix[0, 0];

            for (int c = 1; c < cols; c++)
            {
                dp[0, c] = dp[0, c - 1] + matrix[0, c];
            }

            for (int r = 1; r < rows; r++)
            {
                dp[r, 0] = dp[r - 1, 0] + matrix[r, 0];
            }

        

            for (int r = 1; r < rows; r++)
            {
                for (int c = 1; c < cols; c++)
                {
                    var upper = dp[r - 1, c];
                    var left = dp[r, c - 1];

                    dp[r, c] = Math.Max(upper, left) + matrix[r, c];
                }
            }           
            var path = new Stack<string>();           

            var row = rows - 1;
            var col = cols - 1;

            while (row > 0 && col > 0)
            {
                path.Push($"[{row}, {col}]");

                var upper = dp[row - 1, col];
                var left = dp[row, col - 1];

                if (upper > left)
                {
                    row -= 1;
                }

                else
                {
                    col -= 1;
                }

                
            }
            
            while (row > 0)
                {
                    path.Push($"[{row}, {col}]");
                    row -= 1;
                }

                while (col > 0)
                {
                    path.Push($"[{row}, {col}]");
                    col -= 1;
                }
            
            return path;
        }

        private static void GetHighestSum(int sum, int startRow, int startCol, List<string> currPath)
        {

            if (startRow >= matrix.GetLength(0) || startCol >= matrix.GetLength(1))
            {
                return;
            }

            if (visited[startRow, startCol])
            {
                return;
            }

            if (startRow == matrix.GetLength(0) - 1
                && startCol == matrix.GetLength(1) - 1)
            {
                sum += matrix[startRow, startCol];
                // currPath.Add($"[{startRow}, {startCol}]");


                if (sum > maxSum)
                {
                    maxSum = sum;
                    //  currPath.Add($"[{startRow}, {startCol}]");
                    path.Clear();
                    path.AddRange(currPath);

                    return;
                }
                visited[startRow, startCol] = true;
                return;
            }

            sum += matrix[startRow, startCol];
            visited[startRow, startCol] = true;
            currPath.Add($"[{startRow}, {startCol}]");

            GetHighestSum(sum, startRow + 1, startCol, currPath);
            GetHighestSum(sum, startRow, startCol + 1, currPath);

            visited[startRow, startCol] = false;


        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void FillMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                }
            }
        }


    }
}