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

            string[] result2 = result.Result
                .Split(new[] { '[', ',', ']', '"', '\\' }, StringSplitOptions.RemoveEmptyEntries);
            LoadShibaToFileTxt(result2);

            Console.WriteLine();
        }

        static async Task<string> GetShiba(int count = 1)
        {
            try
            {
                var response = await client.GetStringAsync
                    ($"http://shibe.online/api/shibes?count={count}&urls=true&httpsUrls=false");
                return response;
            }
            catch (Exception)
            {
                Console.WriteLine("URL was invalid...");
                return string.Empty;
            }
        }

        static void LoadShibaToFileTxt(string[] toWrite)
        {   
            File.AppendAllLines("randomShibaPics.txt",toWrite);
        }
    }
}