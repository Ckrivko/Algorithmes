using System;
using System.Linq;

namespace BubbleSort
{
    public class Program
    {
        static void Main(string[] args)
        {

            var arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            BubleSort(arr);
            Console.WriteLine(string.Join(" ", arr));

        }

        //private static void BubleSort(int[] arr)
        //{
        //    for (int i = 0; i < arr.Length; i++)
        //    {

        //        for (int j = i + 1; j < arr.Length; j++)
        //        {

        //            if (arr[j] < arr[i])
        //            {
        //                Swap(arr, i, j);
        //            }
        //        }
        //    }
        //}

        private static void BubleSort(int[] arr)
        {
            var sortedCount = 0;
            var isSorted = false;

            while (!isSorted)
            {
                isSorted = true;

                for (int j = 1; j < arr.Length-sortedCount; j++)
                {

                    var i = j - 1;
                    if (arr[j] < arr[i])
                    {
                        Swap(arr, i, j);
                        isSorted = false;
                    }
                }
                sortedCount += 1;
                
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
