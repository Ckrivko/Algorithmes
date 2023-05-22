using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    public class Program
    {
        private static StringBuilder sb = new StringBuilder();
        private static string[] inputNames;
        private static bool[] used;
        private static HashSet<string> resultNames = new HashSet<string>();

        static void Main(string[] args)
        {
            inputNames = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            used = new bool[inputNames.Length];

            var inputCommand = Console.ReadLine();
            var indexesOfNames = new Dictionary<string, int>();

            while (inputCommand != "generate")
            {
                var name = inputCommand.Split(" - ", StringSplitOptions.RemoveEmptyEntries)[0];
                var index = int.Parse(inputCommand.Split(" - ", StringSplitOptions.RemoveEmptyEntries)[1]) - 1;

                indexesOfNames.Add(name, index);

                inputCommand = Console.ReadLine();
            }

            inputNames = GenerateResultArray(inputNames, indexesOfNames);

            GenerateCinemaPlaces(inputNames, 0);
            Console.WriteLine(sb.ToString().Trim());
        }

        private static string[] GenerateResultArray(string[] inputNames, Dictionary<string, int> indexesOfNames)

        {

            for (int i = 0; i < inputNames.Length; i++)
            {
                var currNmae = inputNames[i];

                if (indexesOfNames.ContainsKey(currNmae))
                {
                    var index = indexesOfNames[currNmae];
                    var temp = inputNames[index];
                    inputNames[index] = currNmae;
                    inputNames[i] = temp;
                    used[index] = true;

                }
            }
            return inputNames;
        }

        private static void GenerateCinemaPlaces(string[] inputNames, int index)
        {
            if (index >= inputNames.Length)
            {
                var currResult = string.Join(" ", inputNames);

                if (!resultNames.Contains(currResult))
                {
                    sb.AppendLine(currResult);
                    resultNames.Add(currResult);
                    return;

                }
              
                return;
            }

            GenerateCinemaPlaces(inputNames, index + 1);

            for (int i = index + 1; i < inputNames.Length; i++)
            {
                Swap(index, i);
                GenerateCinemaPlaces(inputNames, index + 1);
                Swap(index, i);

            }

        }

        private static void Swap(int first, int second)
        {
            if (used[first] == false && used[second] == false)
            {
                var temp = inputNames[first];
                inputNames[first] = inputNames[second];
                inputNames[second] = temp;

            }
        }
    }
}
