using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    public class Current
    {
        [JsonProperty("observation_time")]
        private string observation_time { get; set; }  
        
        [JsonProperty("temperature")]
        private string temperature { get; set; }  
        
        [JsonProperty("Weather_descriptions")]
        private string [] weather_descriptions { get; set; }

        [JsonProperty("wind_speed")]
        private string wind_speed { get; set; }

        [JsonProperty("wind_dir")]
        private string wind_dir { get; set; }  

        [JsonProperty("pressure")]
        private string pressure { get; set; }  
        
        [JsonProperty("humidity")]
        private string humidity { get; set; }          
        
        [JsonProperty("feelslike")]
        private string feelslike { get; set; }     
        
        [JsonProperty("visibility")]
        private string visibility { get; set; }     
    
        public void CurrentWeatherInfo()
        {
            Console.WriteLine($"Observation time: {observation_time}");
            Console.WriteLine($"Temperature: {temperature}");
            Console.WriteLine($"Feelslike: {feelslike}");
            Console.WriteLine($"Wind speed: {wind_speed}");
            Console.WriteLine($"Wind direction: {wind_dir}");
            Console.WriteLine($"Pressure: {pressure}");
            Console.WriteLine($"Humidity: {humidity}");     
            Console.WriteLine($"Visibility: {visibility}");
            Console.WriteLine($"Weather description: {weather_descriptions.FirstOrDefault()}");
        }
    }
}