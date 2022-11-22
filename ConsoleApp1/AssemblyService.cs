using System.Reflection;

namespace ConsoleApp1
{
    internal class AssemblyService
    {
        private Type[] types;
        public static IEnumerable<Type> classes;

        public AssemblyService(string path)
        {            
            var assembly = Assembly.Load(path);
            types = assembly.GetTypes();
            classes = types.Where(x => x.IsClass || x.IsValueType);
        }

        public void GetClassesInfo()
        {
            var classInfo = AssemblyService.classes;
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
    }
}