using System;
using System.Collections.Generic;

namespace ExamAlgorithmsFund
{
    internal class Program
    {
        private static Dictionary<string, long> cashe = new Dictionary<string, long>();
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());
                                

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
            var result = GetBinom(n - 1, k - 1) + GetBinom(n - 1, k);
            cashe.Add($"{n}-{k}", result);

            return result;
        }
    }
}