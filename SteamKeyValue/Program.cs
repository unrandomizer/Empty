using System;
using System.IO;
using SteamKit2;

namespace SteamKeyValue
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientMicroTxnAuthRequest();
        }
        static void ClientMicroTxnAuthRequest()
        {
            byte[] bytes = File.ReadAllBytes("..\\..\\..\\Data\\microtxn.bin");
            MemoryStream ms = new MemoryStream(bytes);
            ms.Seek(37, SeekOrigin.Begin);
            KeyValue kv = new KeyValue();
            kv.TryReadAsBinary(ms);
            if (kv != null)
            {
                foreach (KeyValue babies in kv.Children)
                {
                    Console.WriteLine($"{babies.Name} : {babies.Value}");
                }
            }
            ulong transid = Convert.ToUInt64(kv.Children.Find(kval => kval.Name.Equals("transid", StringComparison.InvariantCultureIgnoreCase)).Value);
            ulong orderid = Convert.ToUInt64(kv.Children.Find(kval => kval.Name.Equals("orderid", StringComparison.InvariantCultureIgnoreCase)).Value);
            ulong currencyid = Convert.ToUInt64(kv.Children.Find(kval => kval.Name.Equals("currency", StringComparison.InvariantCultureIgnoreCase)).Value);
            ulong total = Convert.ToUInt64(kv.Children.Find(kval => kval.Name.Equals("total", StringComparison.InvariantCultureIgnoreCase)).Value);
            ulong billingTotal = Convert.ToUInt64(kv.Children.Find(kval => kval.Name.Equals("BillingTotal", StringComparison.InvariantCultureIgnoreCase)).Value);
            ulong billingCurrency = Convert.ToUInt64(kv.Children.Find(kval => kval.Name.Equals("BillingCurrency", StringComparison.InvariantCultureIgnoreCase)).Value);

            Console.ReadKey();
        }
    }
}
