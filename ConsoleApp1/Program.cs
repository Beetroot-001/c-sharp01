namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
            Product chips = new Product("Lays", "It's chips by Lays", 20, 5);
            Product chips2 = new Product("Estrella", "It's chips by Estrella", 40, 6);
            Product coke = new Product("Nuka Cola", "It's fallout coke", 12, 2);

			Shop myShop = new Shop();

			myShop.AddProduct(chips);
			myShop.AddProduct(chips2);

            Buyer vasia = new Buyer("Vasia", "This our first customer Vasia");
            Buyer kolia = new Buyer("Kolia", "He is a dick");
            Buyer petia = new Buyer("Petia", "He is a good guy");

			myShop.RegisterNewBuyer(vasia);
			myShop.RegisterNewBuyer(kolia);
			myShop.RegisterNewBuyer(petia);

			myShop.ShopMenu();

        }
	}
}