using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    internal class OpenWeatherMapAPI
    {
        public static void weatherForCity()
        {
            //IConfiguration configuration = new ConfigurationBuilder()
            //     .SetBasePath(Directory.GetCurrentDirectory())
            //     .AddJsonFile("appsettings.json")
            //     .Build();

            var apiKey = JObject.Parse(File.ReadAllText("appsettings.json")).GetValue("ApiKey").ToString();                              
            //var apiKey = configuration.GetSection("AppSettings")["ApiKey"];                                                                                                                                                                                   
            var client = new HttpClient();                                                                                                                                                                                                                                      
            Console.WriteLine("Enter name of city: ");                  
            var cityName = Console.ReadLine();                      
            var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=imperial";
            var weatherResponse = client.GetStringAsync(weatherURL).Result;
            JObject weatherObject = JObject.Parse(weatherResponse);
            Console.WriteLine($"It is {weatherObject["main"]["temp"]} degrees fahrenheit in {cityName}");

        }      



    }
}
