using System;
using System.Collections.Generic;
using System.Linq;


namespace SumLimitedAmountCoins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var target = int.Parse(Console.ReadLine());

            var result = CountSums(numbers, target);
            Console.WriteLine(result);
        }

        private static int CountSums(int[] numbers, int target)
        {
            var sums = new HashSet<int> { 0 };
            var count = 0;

            foreach (var number in numbers)
            {
                var newSums = new HashSet<int>();

                foreach (var sum in sums)
                {
                    var newSum = sum + number;

                    if (newSum == target)
                    {
                        count++;
                    }
                    
                    newSums.Add(newSum);
                }
                sums.UnionWith(newSums);
            }

            return count;
        }
    }
}