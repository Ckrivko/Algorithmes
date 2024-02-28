using System;
using System.Collections.Generic;
using System.Linq;


namespace DividingPresents
{
    internal class Program
    {

        static void Main(string[] args)
        {

            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var numOfPresents = input.Length;
            var totalSum = input.Sum();
            var idealTwinSum = totalSum / 2;

            var sums = GetAllPossibleSums(input);
            var subset = FindSubset(sums, idealTwinSum);
          
            var alansSum = subset.Sum();
            var bobSum = totalSum - alansSum;
            var diffSum=bobSum-alansSum;

            Console.WriteLine( $"Difference: {diffSum}");
            Console.WriteLine( $"Alan:{alansSum} Bob:{bobSum}" );
            Console.WriteLine(  $"Alan takes: {string.Join(" ",subset)}");
            Console.WriteLine(  "Bob takes the rest.");


        }

        private static List<int> FindSubset(Dictionary<int, int> sums, int target)
        {
            var subset = new List<int>();
            var counter = 0;

            while (target > 0)
            {
                if (!sums.ContainsKey(target))
                {
                    target = sums.Keys.Where(x => x < target).Max();     //FindNearestTarget(sums, target);
                }

                var num = sums[target];
                target -= num;

                subset.Add(num);
            }

            return subset;
        }

        private static int FindNearestTarget(Dictionary<int, int> sums, int target)
        {
            var differense = int.MaxValue;
            var result = 0;

            foreach (var key in sums.Keys)
            {
                if (key < target)
                {
                    var currDiff = target - key;
                    if (currDiff < differense)
                    {
                        differense = currDiff;
                        result = key;
                    }
                }
            }
            return result;
        }

        private static Dictionary<int, int> GetAllPossibleSums(int[] nums)
        {
            var sums = new Dictionary<int, int> { { 0, 0 } };

            foreach (var num in nums)
            {
                var currentSums = sums.Keys.ToArray();

                foreach (var sum in currentSums)
                {
                    var newSum = sum + num;
                    if (sums.ContainsKey(newSum))
                    {
                        continue;
                    }

                    sums.Add(newSum, num);
                }
            }
            return sums;
        }
    }
}