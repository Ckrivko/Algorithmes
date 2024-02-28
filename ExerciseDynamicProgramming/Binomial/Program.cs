using System;
using System.Collections.Generic;

namespace ExerciseDynamicProgramming
{
    internal class Program
    {
        private static Dictionary<string, long> cashe= new Dictionary<string, long>();

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            var triangle = GeneratePascalTriangle(n);

           // PrintBinom(n, k, triangle);

            //  DisplayTriangle(triangle);

            var result = GetBinom(n, k);
            Console.WriteLine(result);

        }

        private static long GetBinom(int n, int k)
        {
            if (k == 0 || k == n)
            {
              return 1;
            }

            var key = $"{n}-{k}";
            if (cashe.ContainsKey(key))
            {
                return cashe[key];
            }
            else 
            {
            
            }
            var result=GetBinom(n - 1, k - 1) + GetBinom(n - 1, k);
            cashe.Add($"{n}-{k}",result);

            return result;
        }

        private static void PrintBinom(int n, int k, long[][] triangle)
        {
            if (k == 0 || k == n)
            {
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine(triangle[n - 1][k - 1] + triangle[n - 1][k]);

            }
        }

        private static void DisplayTriangle(int[][] triangle)
        {
            for (int i = 0; i < triangle.Length; i++)
            {
                Console.WriteLine(string.Join(" ", triangle[i]));
            }
        }

        private static long[][] GeneratePascalTriangle(int n)
        {
            var triangle = new long[n][];

            for (int i = 0; i < n; i++)
            {
                triangle[i] = new long[i + 1];
                triangle[i][0] = 1;

                for (int j = 1; j < i; j++)
                {

                    triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
                }

                triangle[i][i] = 1;
            }

            return triangle;
        }
    }
}