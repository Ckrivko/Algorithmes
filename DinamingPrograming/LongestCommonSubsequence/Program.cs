using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestCommonSubsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            var lcs = new int[str1.Length + 1, str2.Length + 1];
            var result = GetMaxLCS(lcs, str1, str2);
          
            Console.WriteLine(result);

            Console.WriteLine(PrintLcs(lcs, str1, str2));//.Replace(" ",""));

        }

        private static string PrintLcs(int[,] lcs, string str1, string str2)
        {
            var row = str1.Length;
            var col = str2.Length;

            var lcsletters = new Stack<char>();

            while (row > 0 && col > 0)
            {
                if (str1[row-1] == str2[col-1])
                {
                    lcsletters.Push(str1[row-1]);
                    row--;
                    col--;
                }
                else if (lcs[row - 1, col] > lcs[row, col - 1])
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }

            return string.Join("", lcsletters);
        }

        private static int GetMaxLCS(int[,] lcs, string str1, string str2)
        {
            for (int r = 1; r < lcs.GetLength(0); r++)
            {

                for (int c = 1; c < lcs.GetLength(1); c++)
                {
                    if (str1[r - 1] == str2[c - 1])
                    {
                        lcs[r, c] = lcs[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        lcs[r, c] = Math.Max(lcs[r - 1, c], lcs[r, c - 1]);
                    }

                }
            }

            return lcs[str1.Length, str2.Length];
        }
    }
}