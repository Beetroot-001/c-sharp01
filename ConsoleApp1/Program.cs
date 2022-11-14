using Newtonsoft.Json;

namespace ConsoleApp1
{
    internal class Program
    {
        private static HttpClient client = new HttpClient();
        private static string meowAPI = "https://meowfacts.herokuapp.com/?lang=ukr";
        private static string geoAPI = "http://www.geoplugin.net/json.gp?ip=";

        private static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            DateTime dateTime = DateTime.Now.Date;
            var meow = await GetAPI(meowAPI);
            var geo = await GetAPI(geoAPI);
            GeoData geoData = JsonConvert.DeserializeObject<GeoData>(geo);
            MeowData meowData = JsonConvert.DeserializeObject<MeowData>(meow);
            var lat = geoData.geoplugin_latitude;
            var @long = geoData.geoplugin_longitude;
            string meteo = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={@long}&timezone={geoData.geoplugin_timezone}&daily=temperature_2m_max&daily=temperature_2m_min";
            var getWeat = await GetAPI(meteo);
            WeatherData wethData = JsonConvert.DeserializeObject<WeatherData>(getWeat);
            var minTempList = wethData.daily.temperature_2m_min;
            var maxTempList = wethData.daily.temperature_2m_max;
            Console.WriteLine("Random cat fact:");
            Console.WriteLine(meowData.data.Single());
            Console.WriteLine("Temperature forecast for the next week:");

            for (int i = 0; i < minTempList.Count; i++)
            {
                var res = (minTempList[i] + maxTempList[i]) / 2;
                Console.WriteLine(dateTime.AddDays(i).DayOfWeek);
                Console.WriteLine(res);
            }
        }

        public static async Task<string> GetAPI(string apiAddress)
        {
            var getter = await client.GetAsync(apiAddress);
            var result = await getter.Content.ReadAsStringAsync();
            return result;
        }
    }
}