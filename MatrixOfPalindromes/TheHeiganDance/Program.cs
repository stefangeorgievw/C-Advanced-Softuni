using System;
using System.Linq;

namespace TheHeiganDance
{
    class Program
    {
        static void Main(string[] args)
        {
            var playerHp = 18500;
            var heiganHp = 3000000d;

            var playerRow = 7;
            var playerCol = 7;

            var playersDamage = double.Parse(Console.ReadLine());

            var lastSpell = "";
            while (true)
            {
                if (playerHp >=0 )
                {
                    heiganHp -= playersDamage;
                }

                if (lastSpell == "Cloud")
                {
                    playerHp -= 3500;
                }

                if (heiganHp <= 0 || playerHp <= 0 )
                {
                    break;
                }

                string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string spell = input[0];
                int targetRow = int.Parse(input[1]);
                int targetCol = int.Parse(input[2]);
            }
        }
    }
}
