using System;
using SteamKit2;

namespace SteamKeyValue
{
    class Program
    {
        static void Main(string[] args)
        {
            KeyValue.TryLoadAsBinary("data.bin", out KeyValue kv);
            if (kv != null)
            {
                foreach (KeyValue babies in kv.Children)
                {
                    Console.WriteLine($"{babies.Name} : {babies.Value}");
                }
            }
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
