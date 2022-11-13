namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var shop = new InternetShop("firstShop");
		
			while (true)
			{
                Console.WriteLine();
				MMenu();
				Console.WriteLine("Input key of menu");
				string key = Console.ReadLine() ?? "";
				if (!int.TryParse(key, out var value)) { Console.WriteLine("Input Error.Try Again"); continue; }
				
				switch (value)
                {
					case 1: {
							shop.AddProduct();
						} break;
					case 2: {
							shop.ShowAllProducts();
							shop.AddQuantity();
						} break;
					case 3: {
							shop.ShowAllProducts();
							shop.SellProduct();
							Console.WriteLine();
						} break;
					case 4: {
							Console.WriteLine();
						} break;
					default: 
						Console.WriteLine("Not Found"); 
						break;
                }
            }
		}

		public static void MMenu()
        {
			Console.WriteLine("Menu");
			Console.WriteLine("1.Add New Product");
			Console.WriteLine("2.Add quantity to existent");
			Console.WriteLine("3.sell Product");
			Console.WriteLine("4.register Buyer");
		}
	}
}