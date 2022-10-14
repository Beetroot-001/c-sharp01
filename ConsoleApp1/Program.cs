namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Stack<object> stack = new Stack<object>();
			stack.Push("First");
			stack.Push(2);
			stack.Push("third");
			stack.Push('4');
            Element<object> dellElement = stack.Pop();
			stack.Clear();
			stack.Push("New Element");
			stack.Push("Serhii");
			var element= stack.Peek();

			Element<object>[] elements = new Element<object>[7];
			stack.CopyTo(elements);

			Console.ReadLine();
		}
	}
}