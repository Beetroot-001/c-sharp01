namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Menu menu = Menu.CreateInstance();
			menu.Start();
        }
    }

	static class InputParse
	{
        public static bool TryIntInput(out int result)
        {
			bool success = false;
            do
            {
                success = int.TryParse(Console.ReadLine(), out result);
                Console.WriteLine(success ? "Valid input" : "Invalid input. Try again...");
            } while (!success);
            return success;
        }
    }
}