using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    internal static class SBas_homework_API
    {
        public static async Task<Root> GetWeather(string latitude = "52.52", string longitude = "13.41")
        {
            HttpClient client = new HttpClient();
            var t = await client.GetAsync($"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&hourly=temperature_2m&timezone=Arctic%2FLongyearbyen").Result.Content.ReadAsStringAsync();
            Root root = JsonConvert.DeserializeObject<Root>(t);
            return root ;
        }
    }
}







