using System.Collections;
using static System.Net.Mime.MediaTypeNames;
using System.Net.Http;
using Newtonsoft.Json;
using System.Security.Principal;

namespace ConsoleApp1
{
	internal class Program
	{
        static HttpClient client = new HttpClient();

        static void Main(string[] args)
		{
            var result = GetShiba();

            result.Wait();

            string[] result2 = result.Result
                .Split(new[] { '[', ',', ']', '"', '\\' }, StringSplitOptions.RemoveEmptyEntries);
            Load(result2);

            Console.WriteLine();
        }

        static async Task<string> GetShiba(int count = 1)
        {
            HttpResponseMessage response = await client.GetAsync
                ($"http://shibe.online/api/shibes?count={count}&urls=true&httpsUrls=false");
            Console.WriteLine(response.StatusCode);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        static void Load(string[] toWrite)
        {   
            File.AppendAllLines("randomShibaPics.txt",toWrite);
        }
    }
}