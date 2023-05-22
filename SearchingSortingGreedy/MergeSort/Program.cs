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

           arr= MergeSort(arr);
            Console.WriteLine(string.Join(" ", arr));

        }

        private static int[] MergeSort(int[] arr)
        {
            if (arr.Length <= 1)
            {
                return arr;
            }
            
            var left = arr.Take(arr.Length / 2).ToArray();
            var right = arr.Skip(arr.Length / 2).ToArray();

            return Merge(MergeSort(left), MergeSort(right));

        }

        private static int[] Merge(int[] left, int[] right )
        {
           var merged= new int[left.Length+ right.Length];

            var mergedIdx = 0;
            var leftIdx = 0;
            var rightIdx = 0;

            while (leftIdx < left.Length && rightIdx < right.Length)
            {
                if (left[leftIdx] < right[rightIdx])
                {
                    merged[mergedIdx++] = left[leftIdx++];

                }
                else 
                {
                    merged[mergedIdx++] = right[rightIdx++];
                }

            }

            for (int i = leftIdx; i < left.Length; i++)
            {
                merged[mergedIdx++] = left[i];
            }

            for (int i = rightIdx; i < right.Length; i++)
            {
                merged[mergedIdx++] = right[i];
            }

            return merged;
        }
                
    }
}
