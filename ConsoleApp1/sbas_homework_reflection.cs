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
            string path = Path.Combine("D:\\C#\\Test\\bin\\Debug", "Test.dll"); 
            var assembly = Assembly.LoadFrom(path);

            Type typeAssembly = assembly.GetType();

            foreach (var item in assembly.GetTypes())
            {
                Console.WriteLine($"Name of namespace: {item.Namespace}, Name of types: {item.Name}, Base type: {item.BaseType}");
            }
            
        }
    }
}
