using System;
using System.Collections.Generic;

namespace SubsetSum
{
    internal class Program
    {
        private static bool[] sums;
        private static int[] nums;

        static void Main(string[] args)
        {
            nums = new int[] { 3, 5, 2 };
            var target = int.Parse(Console.ReadLine());     //int.Parse(Console.ReadLine());

            sums = new bool[target + 1];
            sums[0] = true;

            GenerateSums(target);

            var subset = GenerateSubsets(target);

            Console.WriteLine(string.Join(" ", subset));
        }

        private static List<int> GenerateSubsets(int target)
        {
            var subset = new List<int>();

            while (target > 0)
            {
                foreach (var num in nums)
                {
                    var prevSum = target - num;

                    if (prevSum >= 0 && sums[prevSum])
                    {
                        subset.Add(num);
                        target = prevSum;

                        if (target == 0)
                        {
                            break;
                        }
                    }
                }
            }

            return subset;
        }

        private static void GenerateSums(int target)
        {
            for (int sum = 0; sum < sums.Length; sum++)
            {

                if (!sums[sum])
                {
                    continue;
                }

                foreach (var num in nums)
                {
                    var newSum = sum + num;

                    if (newSum > target)
                    {
                        continue;
                    }

                    sums[newSum] = true;
                }
            }
        }
    }
}