namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			MyStack<Person> stack = new MyStack<Person>();
			stack.Push(new Person() { Name = "Andy" });
			Console.WriteLine(stack.Peek().Name);
			stack.Push(new Person() { Name = "Bob" });
			Console.WriteLine(stack.Peek().Name);
			stack.Push(new Person() { Name = "Carl" });
			Console.WriteLine(stack.Peek().Name);
			stack.Push(new Person() { Name = "Dwayne" });
			Console.WriteLine(stack.Peek().Name);
			stack.Push(new Person() { Name = "Evan" });
			Console.WriteLine(stack.Peek().Name);
			stack.Push(new Person() { Name = "Fred" });
			Console.WriteLine(stack.Peek().Name);
			Console.WriteLine(stack.Pop().Name);
			Console.WriteLine(stack.Peek().Name);

			MyStack<int> stackInt = new MyStack<int> { };
			stackInt.Push(1);
			stackInt.Push(2);
			stackInt.Push(3);
			stackInt.Push(4);
			stackInt.Push(5);

			var intArray = new int [8];
			stackInt.CopyTo(intArray);
			stackInt.Clear();
		}
	}
}