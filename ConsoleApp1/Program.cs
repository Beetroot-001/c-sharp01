using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Pizza.PizzaBuilder pizzaBuilder = Pizza.PizzaBuilder.CreateBuilder();

			//Pizza pizza = pizzaBuilder.AddCheese().SetDiameter(40).Build();
			//Pizza pizzaWithOlives = pizzaBuilder.SetDiameter(40).AddOlives().Build();


			//var testClass = new TestClass();
			//Type testClassNewType = typeof(TestClass);

			////foreach (var propertyInfo in testClassNewType.GetProperties())
			////{
			////	var attribute = propertyInfo.GetCustomAttribute<DefaultValueAttribute>();
			////	var propV = propertyInfo.GetValue(testClass);

			////	if (attribute != null && propV == default)
			////	{
			////		propertyInfo.SetValue(testClass, attribute.Value);
			////	}
			////}

			//Console.WriteLine();

			//var testClassInstance = new TestClass()
			//{
			//	DateAndTime = DateTime.Now,
			//	Flag = true,
			//	// FloatValue = 23.5f,
			//	Text = "This is text",
			//	Value = 47
			//};

			//Type testClassType = testClassInstance.GetType();

			//foreach (var property in testClassType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic))
			//{
			//	property.SetValue(testClassInstance, 123.34f);
			//	Console.WriteLine($"Type {property.PropertyType} Name: {property.Name}, Value: {property.GetValue(testClassInstance)}");
			//}

			//testClassType.GetProperty("Value").SetValue(testClassInstance, 123);
			//Console.WriteLine(testClassType.GetProperty("Value").GetValue(testClassInstance));

			//int result = (int)testClassType.GetMethod("MyMethod").Invoke(testClassInstance, new object[] { 123 });

			//var typeName = Console.ReadLine();

			//Console.WriteLine("Type full type's name ");
			//var objectHandler = Activator.CreateInstance(Assembly.GetExecutingAssembly().GetName().Name, typeName);
			//var concreteInstance = objectHandler.Unwrap();

			//Console.WriteLine("Type prop name to modify");
			//var propName = Console.ReadLine();
			//var propertyT = concreteInstance.GetType().GetProperty(propName);
			//Contract.NotNull<ArgumentException>(propertyT, $"There is not such prop {propName}");

			//Console.WriteLine("Type prop value");
			//var propValue = Console.ReadLine();
			//propertyT.SetValue(concreteInstance, propValue);

			//Console.WriteLine(propertyT.GetValue(concreteInstance));

			//Console.WriteLine();

			sbas_homework_reflection sbas_Homework_Reflection = new sbas_homework_reflection();
			sbas_Homework_Reflection.Foo();
		}

	}

	public static class Contract
	{
		public static void NotNull<TException>(object obj, string errorMessage)
			where TException : Exception, new()
		{
			if (obj == null)
			{
				var exceptionInstance = Activator.CreateInstance(typeof(TException), errorMessage) as TException;

				throw exceptionInstance;
			}
		}
	}

	public class TestClass
	{
		[DefaultValue(55)]
		[DefaultValue(55)]
		[DefaultValue(55)]
		[DefaultValue(55)]
		[DefaultValue(55)]
		public int Value { get; set; }

		[MaxLength]
		[DefaultValue("This is default Value")]
		public string Text { get; set; }

		public DateTime DateAndTime { get; set; }


		[DefaultValue(true)]
		public bool Flag { get; set; }

		private float FloatValue { get; set; }


		public int MyMethod(int a)
		{
			return a;
		}
	}
}