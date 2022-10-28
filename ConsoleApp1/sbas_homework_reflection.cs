using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    internal class sbas_homework_reflection
    {
        public void Foo()
        {
            Console.WriteLine("Enter Path for file!");
            string pathforFile = Console.ReadLine() ?? throw new FormatException();

            Console.WriteLine("Enter name Fail");
            string nameFail = Console.ReadLine() ?? throw new FormatException();

            string path = Path.Combine(pathforFile, nameFail);

            var assembly = Assembly.LoadFrom(path)??throw new NullReferenceException();
         
            Type typeAssembly = assembly.GetType();

            foreach (var item in assembly.GetTypes())
            {
                Console.WriteLine("________________Class_____________\n");

                Console.WriteLine($"Name of namespace: {item.Namespace}, Name of types: {item.Name}, Base type: {item.BaseType}");
                Console.WriteLine("__________________Property_______________\n");
                foreach (var item1 in item.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static))
                {
                    Console.WriteLine($"type: {item1.GetType()}, Property name: {item1.Name},Value:  {item1.CanWrite}, Metod:  {item1.GetMethod}, type prop: {item1.PropertyType}");
                }

                Console.WriteLine("________________metods________________\n");
                foreach (var item2 in item.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static))
                {
                    Console.WriteLine("\n");
                    Console.WriteLine($"Metod name: {item2.Name}, Parametrs: {item2.ReturnParameter}, Return type : {item2.ReturnType}, is private: {item2.IsPrivate}");
                    foreach (var item3 in item2.GetParameters())
                    {
                        Console.WriteLine($"Get parametr name: {item3.Name}, type {item3.ParameterType},hes default value: {item3.HasDefaultValue}");
                    }
                }
            }       
        }
    }
}
