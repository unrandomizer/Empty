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
            ms.Seek(1, SeekOrigin.Begin);
            KeyValue kv = new KeyValue();
            kv.TryReadAsBinary(ms);
            if (kv != null)
            {
                foreach (KeyValue babies in kv.Children)
                {
                    Console.WriteLine($"{babies.Name} : {babies.Value}");
                }
            }
            Console.WriteLine(kv.Children.Find(kval => kval.Name.Equals("transid", StringComparison.InvariantCultureIgnoreCase)).Value);
            Console.ReadKey();
        }
    }
}
