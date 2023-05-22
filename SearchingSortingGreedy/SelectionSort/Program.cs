using System;
using System.Linq;

namespace SelectionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

             ColectionSort(arr);
            Console.WriteLine(string.Join(" ",arr));
        }
               

        private static void ColectionSort(int[] arr)
        {          
            for (int i = 0; i < arr.Length; i++)
            {
                var minIndex = GetMinIndex(arr, i, arr.Length);
                Swap(arr, i, minIndex);
               
            }                       
        }

        private static int GetMinIndex(int[] arr, int start, int end)
        {
            var min = int.MaxValue;
            var index = 0;

            for (int i = start; i < end; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                    index = i;
                }

            }
            return index;

        }

        private static void Swap(int[] arr,int first, int second)
        {
            var temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;

        }
    }

}
