namespace ConsoleApp1

{
	internal class Program
	{
		static void Main(string[] args)
		{
			//var myShopContext = new ShopContext();

			Range range = 1..3;

			int[] array = { 1, 2, 3, 4, 5, 6, 7 };

			int[] array2 = array[range];

			foreach (var item in array2)
			{
				Console.WriteLine(item);
			}
        }
	}
}