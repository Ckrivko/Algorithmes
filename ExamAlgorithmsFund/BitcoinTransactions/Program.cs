using System;
using System.Collections.Generic;

namespace BitcoinTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var str1 = Console.ReadLine().Split(" ");
            var str2 = Console.ReadLine().Split(" ");

            var result = FindSimilarity(str1, str2);
            Console.WriteLine($"[{string.Join(" ", result)}]");
        }
        private static Stack<string> FindSimilarity(string[] str1, string[] str2)
        {
            var dp = new int[str1.Length + 1, str2.Length + 1];
            var result = new Stack<string>();


            for (int row = 1; row < dp.GetLength(0); row++)
            {
                for (int col = 1; col < dp.GetLength(1); col++)
                {
                    if (str1[row - 1] == str2[col - 1])
                    {
                        dp[row, col] = dp[row - 1, col - 1] + 1;


                    }
                    else
                    {
                        dp[row, col] = Math.Max(dp[row - 1, col], dp[row, col - 1]);
                    }
                }
            }

            int r = str1.Length;
            int c = str2.Length;

            while (r > 0 && c > 0)
            {
                if (str1[r - 1] == str2[c - 1])
                {
                    result.Push(str1[r - 1]); // Insert at the beginning to maintain order                    
                   
                }
              
                if (dp[r - 1, c] >= dp[r, c - 1])
                {
                    r--;
                }
                else
                {
                    c--;
                }

               
            }


            return result;
        }
    }
}