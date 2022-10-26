using System.Data;
using System.Reflection;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter Assembly file name");
			string name = Console.ReadLine();
			Assembly assembly = Assembly.LoadFile(Path.Combine(Directory.GetCurrentDirectory(), name));
			List<TypeInfo> types = assembly.DefinedTypes.ToList();

			for (int i = 0; i < types.Count; i++)
			{
				Console.Write($"{i + 1}: ");
				TypeDescription(types[i]);
				Console.WriteLine();
			}
		}

		public static void TypeDescription(TypeInfo type)
		{
			Console.WriteLine(type.Name);
			string baseTypeName = type.BaseType is not null ? type.BaseType.Name : "no base type";
			Console.WriteLine($"\tBase class: {baseTypeName}");

			List<FieldInfo> fields = type.DeclaredFields.ToList();
			Console.WriteLine("\tFields: ");
			CheckMembers(fields);
			foreach (FieldInfo field in fields)
			{
				Console.WriteLine($"\t\tName: {field.Name}");
                Console.WriteLine($"\t\t\tType: {field.FieldType.Name}");
            }

			List<ConstructorInfo> constructors = type.DeclaredConstructors.ToList();
			Console.WriteLine("\tConstructors: ");
			CheckMembers(constructors);
			foreach(var item in constructors)
			{
				ConstructorDescription(item);
			}

			List<MethodInfo> methods = type.DeclaredMethods.ToList();
			Console.WriteLine("\tMethods: ");
			CheckMembers(methods);
			foreach (var item in methods)
			{
				MethodDescription(item);
			}
		}

        public static void ConstructorDescription(ConstructorInfo constructor)
		{
			Console.WriteLine($"\t\t{constructor}");
		}

		public static void MethodDescription(MethodInfo method)
		{
			Console.WriteLine($"\t\t{method.Name}");
			Console.WriteLine($"\t\t\tReturn type: {method.ReturnType.Name}");
			List<ParameterInfo> parameters = method.GetParameters().ToList();
			Console.WriteLine("\t\t\tParameters: ");
			CheckMembers(parameters, "\t\t\t\t");
			foreach(var item in parameters)
			{
				Console.WriteLine($"\t\t\t\tName: {item.Name}");
                Console.WriteLine($"\t\t\t\t\tType: {item.ParameterType.Name}");
            }
		}

        public static void CheckMembers<T>(List<T> list, string offset = "\t\t")
        {
            if (list.Count == 0)
            {
                Console.WriteLine($"{offset}no members");
            }
        }
    }
}