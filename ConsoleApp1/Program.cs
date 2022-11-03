using Newtonsoft.Json;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Net;
using System.Security.Principal;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
            Weather checkWeather = new Weather();
			checkWeather.EnterCity();

        }
    }
}