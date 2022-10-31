using Newtonsoft.Json;
using System.Xml.Linq;
using System.Xml.Serialization;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{



			var shop = new Shop
			{
				Owner = new Person
				{
					FullName = "A b"
				},
				Title = "This is super Shop",
				Products = new List<Product>
				{
					new Product("pppppppp")
					{
						Id = Guid.NewGuid(),
						Name = "Apple",
						ExpiredDate = DateTime.Now.AddDays(7),
						Quantity = 10,
						UnitPrice = 10.5m
					},
					new Product("aaaaaa")
					{
						Id = Guid.NewGuid(),
						Name = "Cheese",
						ExpiredDate = DateTime.Now.AddDays(1),
						Quantity = 0,
						UnitPrice = 100.5m
					}
				}
			};

			var @string = JsonConvert.SerializeObject(new object());
			var restoredShop2 = JsonConvert.DeserializeObject<Shop>(@string);

			string binPath = "binary.txt";
			string xmlPath = "data.xml";
			string jsonPath = "data.json";

			//WriteToBinaryFile(binPath, shop);
			//var deserializedShop = ReadFromBinaryFile<Shop>(binPath);

			//WriteToXmlFile(xmlPath, shop);
			//var xmlDeserialized = ReadFromXmlFile<Shop>(xmlPath);

			var rootElement = XElement.Load(xmlPath);

			var res = rootElement.Descendants("Product").Where(x => (int)x.Element("Quantity") > 2);

			WriteToJsonFile(jsonPath, shop);

			var restoredShop = ReadFromJsonFile<Shop>(jsonPath);

			var serializer = new SerializerBuilder()
				.WithNamingConvention(CamelCaseNamingConvention.Instance)
				.Build();

			var yaml = serializer.Serialize(shop);
			System.Console.WriteLine(yaml);

		}

		public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
		{
			using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
			{
				var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				binaryFormatter.Serialize(stream, objectToWrite);
			}
		}

		public static T ReadFromBinaryFile<T>(string filePath)
		{
			using (Stream stream = File.Open(filePath, FileMode.Open))
			{
				var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				return (T)binaryFormatter.Deserialize(stream);
			}
		}

		public static void WriteToXmlFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
		{
			TextWriter writer = null;

			using Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create);

			var serializer = new XmlSerializer(typeof(T));
			serializer.Serialize(stream, objectToWrite);
		}

		public static T ReadFromXmlFile<T>(string filePath) where T : new()
		{
			TextReader reader = null;
			try
			{
				var serializer = new XmlSerializer(typeof(T));
				reader = new StreamReader(filePath);
				return (T)serializer.Deserialize(reader);
			}
			finally
			{
				if (reader != null)
					reader.Close();
			}
		}

		public static void WriteToJsonFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
		{
			TextWriter writer = null;
			try
			{
				var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite);
				writer = new StreamWriter(filePath, append);
				writer.Write(contentsToWriteToFile);
			}
			finally
			{
				if (writer != null)
					writer.Close();
			}
		}

		public static T ReadFromJsonFile<T>(string filePath) where T : new()
		{
			TextReader reader = null;
			try
			{
				reader = new StreamReader(filePath);
				var fileContents = reader.ReadToEnd();
				return JsonConvert.DeserializeObject<T>(fileContents);
			}
			finally
			{
				if (reader != null)
					reader.Close();
			}
		}
	}

	public class Shop
	{
		[JsonIgnore]
		public string Title { get; set; }

		[JsonProperty("producters")]
		public List<Product> Products { get; set; }

		public Person Owner { get; set; }
	}

	public class Person
	{
		public string FullName { get; set; }
	}

	[Serializable]
	public class Product
	{
		public Product(string p)
		{
			P = p;
		}

		public Product()
		{

		}
		public Guid Id { get; set; }
		public string Name { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
		public DateTime ExpiredDate { get; set; }

		public bool IsAvailable => Quantity > 0;

		private string P { get; set; }
	}
}