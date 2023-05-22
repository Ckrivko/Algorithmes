using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolTeams
{
    public class Program
    {
        private static List<string> resultGirls = new List<string>();
        private static List<string> resultBoys = new List<string>();

        static void Main(string[] args)
        {
            var resultGirls = new List<string>();
            var resultBoys = new List<string>();


            var inputGirls = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            var inputBoys = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            // girls- 3, boys- 2

            var girlsCombinations = new string[3];
            var boysCombinations = new string[2];

            var sb = new StringBuilder();

            GenComb(0, 0, inputGirls, girlsCombinations,resultGirls);
            GenComb(0, 0, inputBoys, boysCombinations,resultBoys);

            PrintFinalCombs(resultGirls, resultBoys,sb);
            Console.WriteLine(sb.ToString().Trim());

        }

        private static void PrintFinalCombs(List<string> resultGirls, List<string> resultBoys,StringBuilder sb)
        {
            foreach (var girl in resultGirls)
            {

                foreach (var boy in resultBoys)
                {
                    sb.AppendLine($"{girl}, {boy}");
                }
            }

        }

        private static void GenComb(int index, int startIndex,
            string[] elements, string[] comb,List<string> result )
        {

            if (index >= comb.Length)
            {
                result.Add(string.Join(", ", comb));
                return ;
            }

            for (int i = startIndex; i < elements.Length; i++)
            {
                comb[index] = elements[i];
                GenComb(index + 1, i + 1, elements, comb,result);

            }
        }
    }
}
