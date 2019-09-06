using System;

namespace SteamFees
{
    class Program
    {
        static void Main()
        {
            for (int input = 1; input < 105; input++)
            {
                int receivedAmount = GetPriceToSend(input);
                int correctedInput = GetThirdPartyPrice(receivedAmount);
                string str = $"You receive {receivedAmount / 100f} / Buyer pays {correctedInput / 100f}";
                Console.WriteLine(str);
            }
            Console.WriteLine("Hello World!");
        }
        public static int GetThirdPartyPrice(int priceToSend)
        {
            int steamFee = (int)Math.Floor(Math.Max(priceToSend * 0.05f, 1));
            int publisherFee = (int)Math.Floor(Math.Max(priceToSend * 0.1f, 1));
            int thirdPartyPrice = priceToSend + steamFee + publisherFee;
            return thirdPartyPrice;
        }
        public static int GetPriceToSend(int thirdPartyPrice)
        {
            int steamFee = Math.Max((int)Math.Floor(thirdPartyPrice - thirdPartyPrice / 1.05f), 1);
            int publisherFee = Math.Max((int)Math.Floor(thirdPartyPrice - thirdPartyPrice / 1.1f), 1);
            int priceToSend = Math.Max(thirdPartyPrice - steamFee - publisherFee, 1);
            return priceToSend;
        }
    }
}
