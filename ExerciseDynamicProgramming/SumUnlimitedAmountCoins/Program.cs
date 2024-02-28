using System;
using System.Collections.Generic;
using System.Linq;

namespace SumUnlimitedAmountCoins
{
    internal class Program    {       

        static void Main(string[] args)
        {
           var numbers= Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var target = int.Parse(Console.ReadLine());

            var result= CountSums( numbers, target);
            Console.WriteLine(  result);

        }

        private static int CountSums( int[] numbers, int target)
        {
            var sums = new int[target + 1];
            sums[0] = 1;
                 
            foreach (var number in numbers)              //1 2 5
            {
                for (int sum = number; sum <= target; sum++)
                {                   
                    
                    sums[sum] += sums[sum - number];
                }
            }
            return sums[target];
        }
    }
}