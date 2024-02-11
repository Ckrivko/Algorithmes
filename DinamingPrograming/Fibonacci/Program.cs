using System;
using System.Collections.Generic;

namespace DinamingPrograming
{
    internal class Program
    {
        private static Dictionary<int,long> cashe = new Dictionary<int, long> ();
        static void Main(string[] args)
        {

            var n = int.Parse(Console.ReadLine());

            var result = RecursivelyFibonacci(n);
            Console.WriteLine(result);
        }

        private static long RecursivelyFibonacci(int n)
        {
            if (cashe.ContainsKey(n))
            {
                return cashe[n];
            }
           

            if (n <=1)
            {
                return n;
            }

            var result=RecursivelyFibonacci(n - 1) + RecursivelyFibonacci(n - 2);
            cashe[n] = result;

            return result;
        }
    }
}