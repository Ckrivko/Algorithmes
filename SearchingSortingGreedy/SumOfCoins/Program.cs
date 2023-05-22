using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SumOfCoins
{
   public class Program
    {
        static void Main(string[] args)
        {
            var coins = Console.ReadLine()
              .Split(", ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToList();

            var sum=int.Parse(Console.ReadLine());

            Console.WriteLine(GreedeSolution(coins,sum));
        }

        private static string GreedeSolution(List<int> coins, int sum)
        {
            var sb = new StringBuilder();  
            
            coins.Sort();
            coins.Reverse();

            var coinsToTake = 0;
            

            foreach (var coin in coins)
            {
                coinsToTake += sum / coin;
                var currCoinsToTake = sum / coin;
               
                if (currCoinsToTake == 0)
                {
                    continue;
                }
               
                sb.AppendLine($"{currCoinsToTake} coin(s) with value {coin}");

                sum = sum % coin;
               
                if (sum == 0)
                {
                    break;
                }
            
            }
            if (sum == 0)
            {
                var result= sb.ToString().Trim();
                return $"Number of coins to take: {coinsToTake}\n"+ result;
            }
            else 
            {
                return "Error";
            }

            
        }
    }
}
