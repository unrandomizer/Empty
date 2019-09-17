using System;

namespace Dota2Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            Treasure treasure = new Treasure();
            for (int i = 0; i < 5000; i++)
            {
                treasure.Open();
                Console.WriteLine($"#{i} {treasure.totalSpent/100} {treasure.totalWin/100} {treasure.totalWin / (float)treasure.totalSpent}");
            }
            //Console.WriteLine($"{treasure.totalSpent} {treasure.totalWin} {treasure.totalWin / (float)treasure.totalSpent}");
            Console.ReadKey();
        }
    }
    class Treasure
    {
        public ulong totalWin = 0;
        public ulong totalSpent = 0;
        ulong selfPrice = 19042;
        ulong regularPrice = 6064;// 12260  4340 5800 3878 5931 6349 3896 
        ulong rarePrice = 19161;
        ulong veryRarePrice = 20600;
        ulong ultraRarePrice = 550000;
        int countTotal = 0;
        int countRare = 0;
        int countVeryRare = 0;
        int countUltraRare = 0;
        int[] rareOdds = { 20000, 5830, 1870, 880, 510, 330, 230, 170, 131, 104, 85, 71, 60, 52, 45, 40, 36, 32, 29, 26, 24, 22, 21, 19, 18, 17, 16, 15, 15, 14, 13, 13, 12, 12, 12, 11, 11, 11, 11, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
        int[] veryRareOdds = { 100000, 16580, 4740, 2170, 1230, 800, 560, 410, 320, 250, 210, 170, 141, 121, 105, 92, 81, 72, 65, 58, 53, 48, 45, 41, 35, 35, 33, 31, 29, 27, 26, 24, 23, 22, 21, 20, 19, 18, 18, 17, 16, 16, 15, 15, 14, 14, 14, 13, 13, 13, 13, 12, 12, 12, 12, 12, 11, 11, 11, 11, 11, 11, 11, 10 };
        int[] ultraRareOdds = { 1000000, 273800, 86140, 40210, 23030, 14860, 10370, 7640, 5860, 4640, 3760, 3110, 2620, 2230, 1930, 1680, 1480, 1310, 1170, 1050, 950, 860, 790, 720, 660, 610, 570, 530, 490, 460, 430, 400, 380, 350, 330, 320, 300, 280, 270, 260, 240, 230, 220, 210, 200, 190, 190, 180, 170, 170, 160, 150, 143, 138, 133, 128, 124, 119, 115, 112, 108, 105, 101, 98, 95, 93, 90, 87, 85, 83, 81, 79, 77, 76, 75, 74, 73, 72, 71, 70,70,69,69,68,68,68,67,67,67,67 };
        Random rand = new Random();
        public void Open()
        {
            countTotal++;
            countRare++;
            countVeryRare++;
            countUltraRare++;
            totalSpent += selfPrice;
            int dice = rand.Next(0, ultraRareOdds[countUltraRare - 1]);
            if (dice <= 10)
            {
                totalWin += ultraRarePrice;
                Console.WriteLine("UltraRare win!");
                countUltraRare = 0;
            }
            dice = rand.Next(0, veryRareOdds[countVeryRare - 1]);
            if (dice <= 10)
            {
                totalWin += veryRarePrice;
                Console.WriteLine("VeryRare win!");
                countVeryRare = 0;

            }
            dice = rand.Next(0, rareOdds[countRare - 1]);
            if (dice <= 10)
            {
                totalWin += rarePrice;
                Console.WriteLine("Rare win!");
                countRare = 0;
            }
            totalWin += regularPrice;
        }
    }
}
// regular 
// rare 
// very rare
// ultra rare