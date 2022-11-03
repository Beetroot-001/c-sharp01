using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Weather
    {
        [JsonProperty("location")]
        private Results location;

        [JsonProperty("current")]
        private Current current;
     
        private void PrintWeather()
        {
            location.LocationInfo();
            current.CurrentWeatherInfo();
        }

        private void GetWeatherForecast(string city)
        {
            HttpClient client = new HttpClient();

            string apiUrl = $"http://api.weatherstack.com/current?access_key=038f58b1cb7e69df48eed90066f68322&query={city}";

            var result = client.GetAsync(apiUrl).Result.Content.ReadAsStringAsync().Result;
           
            client.Dispose();       

            Weather weather = JsonConvert.DeserializeObject<Weather>(result);

            if (weather.location == null)
            {
                Console.WriteLine("The city is not found");
                return;
            }
            weather.PrintWeather();
        }

        public void EnterCity()
        {
            Console.WriteLine("Please, enter the name of the city where you want to see the weather");

            string city = Console.ReadLine();

            GetWeatherForecast(city);
        }
    }
}
