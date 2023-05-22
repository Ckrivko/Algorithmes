using System;
using System.Linq;

namespace BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse).ToArray();

            var num = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(arr, num));
        }

        private static int BinarySearch(int[] arr, int num)
        {

            if (num < arr[0] || num > arr[arr.Length - 1])
            {
                return -1;

            }
            var left = 0;
            var right = arr.Length - 1;

            while (left <= right)
            {
                var mid = (left + right) / 2;

                if (arr[mid] == num)
                {
                    return mid;
                }

                if (arr[mid] < num) //going right
                {
                    left = mid+1;
                }
                else
                {
                    right = mid-1;  //going left
                }
            }

            return -1;
        }
    }
}
