using System.Collections.Generic;


namespace ConsoleApp1
	
{
	internal class Program
	{
		static void Main(string[] args)
		{
			StackList<string> list = new StackList<string>();

			list.Push("anna");
			list.Push("bob");
			list.Push("casy");

			string[] array = new string[4];

			list.CopyTo(array);

			foreach (var item in array)
			{
				Console.WriteLine(item);
			}
	
        }
    }
}