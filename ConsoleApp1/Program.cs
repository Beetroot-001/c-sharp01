using System.Drawing;
using System.Reflection;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            AssemblyService assemblyService = new("ConsoleApp1");
            assemblyService.GetClassesInfo();
        }        
    }
}