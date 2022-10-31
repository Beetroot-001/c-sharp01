using System.Diagnostics;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var res = 0;
			Thread thread = new Thread(() =>
			{
				Thread.Sleep(1000);
				res = 25;
			});

			thread.IsBackground = true;

			thread.Start();

			thread.Join();

			Console.WriteLine(res);

			Console.Write("Hello");
		}

		public async Task M()
		{
			HttpClient client = new HttpClient();
			await client.GetByteArrayAsync("https://place.dog/300/200");

			CancellationTokenSource cts = new CancellationTokenSource();
			var token = cts.Token;

			var stopWatch = new Stopwatch();

			stopWatch.Start();
			var tasks = Enumerable.Range(0, 10).Select(x => client.GetByteArrayAsync("https://place.dog/300/200")).ToList();
			await Task.WhenAll(tasks);
			stopWatch.Stop();
			Console.WriteLine($"Ellapsed time {stopWatch.Elapsed}");
			stopWatch.Reset();

			stopWatch.Start();
			foreach (var item in Enumerable.Range(0, 10))
			{
				await client.GetByteArrayAsync("https://place.dog/300/200");
			}
			stopWatch.Stop();


			Console.WriteLine($"Ellapsed time {stopWatch.Elapsed}");

			cts.Cancel();

			var program = new Program();

			var task = program.DoSomething();


			stopWatch.Start();

			Task? heatWaterTask = HeatUpWater();
			Task? headAPanTask = HeatUpPan();

			await PourAGlassOfJuice();

			await headAPanTask;

			Task? beconTask = Fry3SlicesOfBacon();
			Task? eggsTask = Fry2Eggs();
			Task? fryResult = Task.WhenAll(beconTask, eggsTask);

			var result = await task;

			await heatWaterTask;

			Task? coffeeTask = MakeACupOfCoffee();

			await Task.WhenAll(fryResult, coffeeTask);

			await ServeATable();
			await EatBreakfast();

			stopWatch.Stop();

			Console.WriteLine($"Ellapsed time {stopWatch.Elapsed}");
		}


		public static async Task HeatUpWater()
		{
			Console.WriteLine("Started HeatUpWater");
			await Task.Delay(5000);
			Console.WriteLine("Water has been heat up");

		}

		public static async Task HeatUpPan()
		{
			Console.WriteLine("Started HeatUpPan");
			await Task.Delay(4000);
		}

		public static async Task Fry2Eggs()
		{
			Console.WriteLine("Started Fry2Eggs");
			await Task.Delay(3000);
		}

		public static async Task Fry3SlicesOfBacon()
		{
			Console.WriteLine("Started Fry3SlicesOfBacon");
			await Task.Delay(2000);
		}

		public static async Task PourAGlassOfJuice()
		{
			Console.WriteLine("Started PourAGlassOfJuice");
			Task.Delay(1000);
		}

		public static async Task MakeACupOfCoffee()
		{
			Console.WriteLine("Started MakeACupOfCoffee");
			await Task.Delay(2000);
		}

		public static async Task ServeATable()
		{
			Console.WriteLine("Started ServeATable");
			await Task.Delay(3000);
		}

		public static async Task EatBreakfast()
		{
			Console.WriteLine("Started EatBreakfast");
			await Task.Delay(10000);
		}

		public Task<int> DoSomething(CancellationToken cancellationToken)
		{
			Console.WriteLine("DoSomething");
			// throw new Exception();

			return Task.Run(async () =>
			{
				while (!cancellationToken.IsCancellationRequested)
				{
					await Task.Delay(1000);
					Console.WriteLine("Running");
					await Task.Delay(1000);
					Console.WriteLine("Running");
					await Task.Delay(1000);
					Console.WriteLine("Running");
				}
				

				return 45;
			});
		}
	}
}