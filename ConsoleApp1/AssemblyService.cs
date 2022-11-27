using System.Reflection;

namespace ConsoleApp1
{
    public class AssemblyService
    {
        private Type[] types;
        private static IEnumerable<Type> classes;
        public Assembly assembly1 { get; set; }

        public AssemblyService(string path)
        {
            assembly1 = Assembly.Load(path);
        }

        public void GetClassesInfo(Assembly? assembly)
        {
            types = assembly.GetTypes();
            classes = types.Where(x => x.IsClass || x.IsValueType);
            var classInfo = classes;
            foreach (Type? objType in classInfo)
            {
                if (objType.IsClass)
                    Console.WriteLine(" Class " + objType.Name);
                else if (objType.IsValueType && !objType.IsEnum)
                    Console.WriteLine(" Struct " + objType.Name);
                else Console.WriteLine(" Enum " + objType.Name);
                Console.WriteLine("  Props: ");
                var props = objType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                if (props != null && props.Any())
                {
                    foreach (PropertyInfo property in props)
                    {
                        Console.WriteLine("   Property " + property.Name);
                    };
                }
                else Console.WriteLine("   None");
                Console.WriteLine("  Methods: ");
                var methods = objType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
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