using System;
using System.Linq;

namespace BinarySearchRecursively
{
    public class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            var num = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearchRecursively(arr, num, 0, arr.Length - 1));
        }

        private static int BinarySearchRecursively(int[] arr, int num, int left, int right)
        {
            if (num < arr[left] || num > arr[right])
            {
                return -1;

            }

            if (left > right)
            {
                return -1;
            }

            var mid = (left + right) / 2;
          
            if (arr[mid] == num)
            {
                return mid;
            }

            if (arr[mid] < num)
            {
                BinarySearchRecursively(arr, num, mid + 1, right);
            }

            else 
            {
                BinarySearchRecursively(arr, num, left, mid-1);
            }

            return -1;
        }
    }
}
