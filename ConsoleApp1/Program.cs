namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Products apple = new Products(5, 6, "Apple", 10);
			IShop shop = new InternetShop();

			shop.RegisterNewProduct(apple);
			shop.SellProduct(apple);

        }
	}
}