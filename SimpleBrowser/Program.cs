using System;

namespace SimpleBrowser
{
    class Program
    {
        static void Main(string[] args)
        {
            Browser browser = new Browser();
            var result = browser.UrlPostToHttp("https://example.com/");
            string resp = result.Result.Content.ReadAsStringAsync().Result;
            Console.WriteLine(resp);
            Console.ReadKey();
        }
    }
}
