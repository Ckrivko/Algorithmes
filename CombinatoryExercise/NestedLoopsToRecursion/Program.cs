using System;

namespace NestedLoopsToRecursion
{
    public class Program
    {
        private static int[] result;

        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());

            result = new int[input];
            LoopRecursively(input,0);
        }

        private static void LoopRecursively(int n,int idx)
        {
            if (idx >= result.Length)
            {
                Console.WriteLine(string.Join(" ",result));
                return;
            }

            for (int i = 1; i <= n; i++)
            {

                result[idx]=i;
                LoopRecursively(n, idx + 1);
            }
        }
    }
}
