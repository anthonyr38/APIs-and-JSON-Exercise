using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    public class RonVSKanyeAPI
    {
        public static void Conversation()
        {
            var client = new HttpClient();

            for (int i = 0; i < 5; i++) 
            {
                Console.WriteLine($"Ron:\n{SwansonQuote(client)}\n");
                Thread.Sleep(3000);
                Console.WriteLine($"Kanye:\n{KanyeQuote(client)}\n");
                Thread.Sleep(3000);
            }
        }
        private static string SwansonQuote(HttpClient client)
        {
            var jText = client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;

            var quote = JArray.Parse(jText).ToString().Replace('[', ' ').Replace(']', ' ').Replace('"', ' ').Trim();

            return quote;
        }

        private static string KanyeQuote(HttpClient client)
        {
            var jText = client.GetStringAsync("https://api.kanye.rest/").Result;

            var quote = JObject.Parse(jText).GetValue("quote").ToString();

            return quote;
        }
    }
}
