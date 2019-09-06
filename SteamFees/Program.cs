using System;

namespace SteamFees
{
    class Program
    {
        static void Main()
        {
            for (uint input = 1; input < 50; input++)
            {
                uint receivedAmount = GetPriceToSend(input);
                uint correctedInput = GetThirdPartyPrice(receivedAmount);
                string str = $"You receive {receivedAmount / 100f} / Buyer pays {correctedInput / 100f}   #{input}";
                Console.WriteLine(str);
            }
            Console.WriteLine("Hello World!");
        }
        public static uint GetThirdPartyPrice(uint priceToSend)
        {
            uint steamFee = (uint)Math.Floor(Math.Max(priceToSend * 0.05f, 1));
            uint publisherFee = (uint)Math.Floor(Math.Max(priceToSend * 0.1f, 1));
            uint thirdPartyPrice = priceToSend + steamFee + publisherFee;
            return thirdPartyPrice;
        }
        public static uint GetPriceToSend(uint thirdPartyPrice)
        {
            float totalFee = Math.Max((uint)Math.Floor(thirdPartyPrice - thirdPartyPrice / 1.15f), 1);
            uint steamFee = Math.Max((uint)Math.Floor(totalFee / 3f), 1);
            uint publisherFee = Math.Max((uint)Math.Floor(Math.Floor(totalFee / 3f) * 2f), 1);
            uint priceToSend = (uint)Math.Max((int)(thirdPartyPrice - steamFee - publisherFee), 1);          
            return priceToSend;
        }
    }
}
