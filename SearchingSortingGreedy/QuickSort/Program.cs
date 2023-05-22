using System;
using System.Linq;

namespace QuickSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray();

            QuickSort(arr, 0, arr.Length - 1);
            Console.WriteLine(string.Join(" ", arr));

        }

        private static void QuickSort(int[] arr, int start, int end)
        {
            if (start >= end)
            {
                return;
            }


            var pivot = start;
            var left = start + 1;
            var right = end;

            while (left <= right)
            {
                if (arr[left] > arr[pivot] &&
                    arr[right] < arr[pivot])
                {
                    Swap(arr, left, right);
                }

                if (arr[left] <= arr[pivot])
                {
                    left += 1;
                }

                if (arr[right] >= arr[pivot])
                {
                    right -= 1;
                }

            }

            Swap(arr, pivot, right);

            var isLeftSubArraySmaller = right - 1 - start < end - (right + 1);
            if (isLeftSubArraySmaller)
            {

                QuickSort(arr, start, right);
                QuickSort(arr, right + 1, end);
            }
            else
            {
                QuickSort(arr, right + 1, end);
                QuickSort(arr, start, right);
            }

        }

        private static void Swap(int[] arr, int first, int second)
        {
            var temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;

        }
    }
}
