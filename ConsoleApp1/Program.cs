using System.Drawing;
using System.Reflection;

namespace ConsoleApp1
{
    internal class Program
    {
        internal class GetReflection
        {
            private Type[] types;
            public static IEnumerable<Type> classes;

            public GetReflection()
            {
                types = Assembly.GetAssembly(typeof(Program))?.GetTypes();
                classes = types.Where(x => x.IsClass || x.IsValueType);
            }
        }

        private static void Main(string[] args)
        {
            GetReflection getReflection = new();
            var classInfo = GetReflection.classes;
            Console.WriteLine("Classes: ");
            foreach (Type? assembly in classInfo)
            {
                if (assembly.IsClass)
                    Console.WriteLine(" Class " + assembly.Name);
                else if (assembly.IsValueType && !assembly.IsEnum)
                    Console.WriteLine(" Struct " + assembly.Name);
                else Console.WriteLine(" Enum " + assembly.Name);

                Console.WriteLine("  Props: ");
                var props = assembly.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                if (props != null && props.Any())
                {
                    foreach (PropertyInfo property in props)
                    {
                        Console.WriteLine("   Property " + property.Name);
                    };
                }
                else Console.WriteLine("   None");
                Console.WriteLine("  Methods: ");
                var methods = assembly.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
                if (methods != null && methods.Any())
                {
                    foreach (MethodInfo method in methods)
                    {
                        ParameterInfo[] parameters = method.GetParameters();
                        Console.WriteLine("  Method " + method.Name);
                        Console.WriteLine("  Parameters: ");
                        if (parameters != null && parameters.Any())
                        {
                            foreach (ParameterInfo parameter in parameters)
                            {
                                Console.WriteLine("   Parameter  " + parameter.Name + " " + parameter.ParameterType + "\r\n    Return Type: " + method.ReturnType);
                            }
                        }
                        else Console.WriteLine("   None");
                    }
                }
                else Console.WriteLine("   None ");
                Console.WriteLine();
            }
        }

        public class Person
        {
            public string Name { get; set; }
            public string FirstName { get; set; }
            private int Age { get; set; } = 0;

            private void AgeOne()
            {
                Age++;
            }
        }

        private class Apple
        {
            private Color AppleColor { get; set; }
            private int Size { get; set; }
            private int Count { get; set; }

            private struct Weight
            {
            }
        }
    }
}