using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace PricesJam
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string json = File.ReadAllText("rates.json");
            RatesReport report = JsonConvert.DeserializeObject<RatesReport>(json);            
            foreach (var smth in report.Currencies)
            {
                Console.WriteLine(smth.ISOName);
            }
        }
        public class RatesReport
        {
            public List<CurrencyRate> Currencies { get; set; }
        }
        public class CurrencyRate
        {
            public string ISOName { get; set; }
            public double SteamRate { get; set; }
        }
    }
}
