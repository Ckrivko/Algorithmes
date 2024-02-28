using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectingCables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse).ToArray();

            var positions = Enumerable.Range(1, numbers.Length).ToArray();


            var result = FindPairs(numbers, positions);
            Console.WriteLine(  $"Maximum pairs connected: {result}");

        }

        private static int FindPairs(int[] numbers, int[] positions)
        {
            var dp = new int[numbers.Length + 1, numbers.Length + 1];
            dp[0, 0] = 0;

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                for (int col = 1; col < dp.GetLength(1); col++)
                {
                    if (numbers[row - 1] == positions[col - 1])
                    {
                        dp[row, col] = dp[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        dp[row, col] = Math.Max(dp[row - 1, col], dp[row, col - 1]);
                    }
                }
            }

            return dp[numbers.Length, numbers.Length];
        }
    }
}