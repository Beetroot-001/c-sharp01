using System.Reflection;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
            PrintAssemblyInfo myAssembly = new PrintAssemblyInfo("ConsoleApp1");
            myAssembly.ShowClassesInfo();
        }
	}
}