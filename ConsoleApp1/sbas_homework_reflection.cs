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
            string path = Path.Combine("D:\\C#\\Test_snake\\bin\\Debug\\net6.0", "Test_snake.dll"); 
            var assembly = Assembly.LoadFrom(path);

            Type typeAssembly = assembly.GetType();

            foreach (var item in assembly.GetTypes())
            {
                Console.WriteLine("________________Class_____________\n");

                Console.WriteLine($"Name of namespace: {item.Namespace}, Name of types: {item.Name}, Base type: {item.BaseType}");
                Console.WriteLine("__________________Property_______________\n");
                foreach (var item1 in item.GetProperties())
                {
                    Console.WriteLine($"type: {item1.GetType()}, Property name: {item1.Name},Value:  {item1.CanWrite}, Metod:  {item1.GetMethod}, type prop: {item1.PropertyType}");
                }

                Console.WriteLine("________________metods________________\n");
                foreach (var item2 in item.GetMethods())
                {
                    Console.WriteLine("\n");
                    Console.WriteLine($"Metod name: {item2.Name}, Parametrs: {item2.ReturnParameter}, Return type : {item2.ReturnType}, is private: {item2.IsPrivate}");
                }
            }       
        }
    }
}
