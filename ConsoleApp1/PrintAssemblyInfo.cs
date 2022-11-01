using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.PrintAssemblyInfo;

namespace ConsoleApp1
{
    internal class PrintAssemblyInfo
    {
        private Assembly myAssembly;

        public PrintAssemblyInfo(string assemblyName)
        {
            myAssembly = Assembly.Load(assemblyName);           
        }

        public void ShowClassesInfo() 
        {
            var classes = myAssembly.GetTypes();

            foreach (var concreteClass in classes)
            {
                if (!concreteClass.IsSealed)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Class name: {concreteClass.Name}");
                    Console.ResetColor();

                    foreach (var method in concreteClass.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.NonPublic))
                    {
                        int counter = 1;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"Method name: {method.Name}");
                        Console.ResetColor();

                        var access = method.IsPublic ? "public" : "private";

                        Console.WriteLine($"Class access: {access}");
                        Console.WriteLine($"Return type: {method.ReturnType}");

                        foreach (var parametr in method.GetParameters())
                        {
                            Console.WriteLine($"Parametr{counter} name: {parametr.Name} ");
                            Console.WriteLine($"Parametr{counter} type: {parametr.ParameterType} ");
                            counter++;
                        }
                    }

                }

            }

        }

    }
}
