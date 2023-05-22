using System;
using System.Linq;

namespace LinearSearch

{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var num = int.Parse(Console.ReadLine());

            Console.WriteLine(LinearSearch(arr,num));
        }

        private static int LinearSearch(int[] arr, int num)
        {
            if (num < arr[0] || num > arr[arr.Length - 1])
            {
                return -1;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == num)
                { 
                return i;
                }
            }

            return -1;
        }
    }
}
