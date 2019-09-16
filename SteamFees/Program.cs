using System;

namespace SteamFees
{
    class Program
    {
        static void Main()
        {
            for (uint input = 0; input < 150; input++)
            {
                uint receivedAmount = GetPriceToSend(input);
                uint correctedInput = GetThirdPartyPrice(receivedAmount);
                string str = $"You receive {receivedAmount / 100f} / Buyer pays {correctedInput / 100f}  input was {input}";
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
        public static uint GetPriceToSend(uint inputTPP)
        {
            if (inputTPP <= 3)
            { return 1; }
            uint estResult = (uint)Math.Ceiling(inputTPP / 1.15f) + 1;
            while (true)
            {
                uint TPP = GetThirdPartyPrice(estResult);
                if (TPP <= inputTPP)
                { return estResult; }
                estResult--;
            }
        }
    }
}
