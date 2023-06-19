using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace APIsAndJSON
{
    public class OpenWeatherMapAPI
    {
        public static void GetTemp()
        {
            // appsettings file
            var apiKeyObj = File.ReadAllText("appsettings.json");

            //api key from appsettings
            var apiKey = JObject.Parse(apiKeyObj).GetValue("apiKey").ToString();

            //zip code for forecast
            Console.WriteLine("Enter Zip Code:");

            var zipCode = Console.ReadLine();

            //var zipCode = 33032;

            // url using zip and api key variables
            var url = $"http://api.openweathermap.org/data/2.5/weather?zip={zipCode}&appid={apiKey}&units=imperial";

            //makes api call
            var client = new HttpClient();

            //api call json formatted as string
            var res = client.GetStringAsync(url).Result;

            //parse string as json object - can be indexed like an array
            var weather = JObject.Parse(res);

            //show info - use weather and index needed properties
            Console.WriteLine($"Temp: {weather["main"]["temp"]}");


        }
    }
}
