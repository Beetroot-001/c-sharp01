namespace ConsoleApp1
{
    public static class MyParse
    {
        public static bool IntParse(out int result, string entervalue = "number")
        {
            bool success = false;
            string message = "";
            do
            {
                Console.WriteLine($"Enter {entervalue}: ");
                success = int.TryParse(Console.ReadLine(), out result);
                message = success ? "Valid input!" : "Invalid input, try again!";
                Console.WriteLine(message);

            } while (!success);
            return success;
        }
    }
}