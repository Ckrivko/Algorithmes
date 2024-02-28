using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumEditDistance
{
    internal class Program
    {
        private static int replaceCost;
        private static int insertCost;
        private static int deleteCost;
        static void Main(string[] args)
        {
            replaceCost = int.Parse(Console.ReadLine());
            insertCost = int.Parse(Console.ReadLine());
            deleteCost = int.Parse(Console.ReadLine());

            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            var result = FindMinimumEditDistance(str1, str2);
            Console.WriteLine(result);
        }

        private static string FindMinimumEditDistance(string? str1, string? str2)
        {
            var dp = new int[str1.Length + 1, str2.Length + 1];

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                dp[row, 0] = dp[row - 1, 0] + deleteCost;
            }

            for (int col = 1; col < dp.GetLength(1); col++)
            {
                dp[0, col] = dp[0, col - 1] + insertCost;
            }

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                for (int col = 1; col < dp.GetLength(1); col++)
                {
                    if (str1[row - 1] == str2[col - 1])
                    {
                        dp[row, col] = dp[row - 1, col - 1];
                    }

                    else
                    {
                        var replace = dp[row - 1, col - 1] + replaceCost;
                        var delete = dp[row - 1, col] + deleteCost;
                        var insert = dp[row, col - 1] + insertCost;

                        dp[row, col] = Math.Min(Math.Min(replace, delete), insert);
                    }
                }

            }
                return $"Minimum edit distance: {dp[str1.Length, str2.Length]}";

        }
    }
}