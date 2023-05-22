using System;

namespace ReverseArray
{
    public class Program
    {
        private static string[] result;

        static void Main(string[] args)
        {

            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            result = new string[input.Length];
            ReverseArray(input,0);
        }

        private static void ReverseArray(string[] input,int idx)
        {
            if (idx >= input.Length)
            {
                Console.WriteLine(string.Join(" ",result));
                return;
            }

            result[idx] = input[input.Length-1-idx];
            ReverseArray(input, idx + 1);
        }
    }
}
