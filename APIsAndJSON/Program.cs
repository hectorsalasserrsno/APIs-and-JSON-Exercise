using Newtonsoft.Json.Linq;
using System;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            OpenWeatherMapAPI.weatherForCity();

            HttpClient client = new HttpClient();

            string ronUrl = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            string kanyeUrl = "https://api.kanye.rest/";

            for (int i = 1; i <= 5; i++)
            {

                var ronResponse = client.GetStringAsync(ronUrl).Result;
                var ronQuote = JArray.Parse(ronResponse);

                var kanyeResponse = client.GetStringAsync(kanyeUrl).Result;
                var kanyeQuote = JObject.Parse(kanyeResponse);
                Console.WriteLine();

                Console.WriteLine($"Ron {ronQuote[0]}");
                Console.WriteLine($"Kanye {kanyeQuote["quote"]}");


            }
        }
    }
}
