using Newtonsoft.Json;

namespace ConsoleApp1
{
    internal class Results
    {
        [JsonProperty("name")]
        private string name { get; set; }
        
        [JsonProperty("country")]
        private string country { get; set; }

        [JsonProperty("region")]
        private string region { get; set; }

        [JsonProperty("timezone_id")]
        private string timezone_id { get; set; } 
        
        [JsonProperty("localtime")]
        private string localtime { get; set; }

        public void LocationInfo()
        {
            Console.WriteLine($"City: {name}");
            Console.WriteLine($"Country: {country}");
            Console.WriteLine($"Region: {region}");
            Console.WriteLine($"Timezone id: {timezone_id}");
            Console.WriteLine($"Local time: {localtime}");
        }

    }
}