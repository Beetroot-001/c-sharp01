using System.Reflection;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var info = Assembly.GetAssembly(typeof(Program))?.GetTypes();

			var classesInfo = info.Where(x => x.IsClass);
			Console.WriteLine("Classes: ");
			foreach (var assembly in classesInfo)
			{
				Console.WriteLine(assembly.Name);

				Console.WriteLine("Properties: ");
				foreach (var property in assembly.GetProperties())
				{
					Console.WriteLine(property.Name);
				}
				Console.WriteLine();

				Console.WriteLine("Methods: ");
				foreach (var method in assembly.GetMethods())
				{
					Console.WriteLine(method.Name);
					var param = method.GetParameters();

					Console.WriteLine("Parameters: ");
					foreach (var parameter in param)
					{
						Console.WriteLine(parameter.Name);
						Console.WriteLine(parameter.ParameterType);
                    }
					Console.WriteLine();

					Console.WriteLine("Return type: ");
					Console.WriteLine(method.ReturnType);
					Console.WriteLine();
				}
				Console.WriteLine();
            }

			Console.WriteLine();
		}
	}

	internal class Fruit
	{
		public string Name { get; set; }

		public void Print()
		{
			Console.WriteLine(Name);
		}
	}

	internal class Car
	{
		public int ID { get; set; }

		public bool IsAlive { get; set; }

		public int NewID(int newId)
		{	
			ID = newId;
			return IsAlive ? newId : ID;
		}
	}


}