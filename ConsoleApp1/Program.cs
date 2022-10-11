namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Stack<int> stack = new Stack<int>();
			stack.Push(1);
			stack.Push(2);
			stack.Push(3);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Count());
            int[] longs = null;
            stack.CopyTo(ref longs);
            for (int i = 0; i < longs.Length; i++)
            {
                Console.WriteLine(longs[i]);
            }
            Stack<string> stack1 = new Stack<string>();
            stack1.Push("hello");
            stack1.Push("world");
            stack1.Push("!");
            Console.WriteLine(stack1.Pop());
            Console.WriteLine(stack1.Pop());
            Console.WriteLine(stack1.Peek());
            Console.WriteLine(stack1.Peek());
            Console.WriteLine(stack1.Count());           
            string[] strings = null;
            stack1.CopyTo(ref strings);
            for (int i = 0; i < strings.Length; i++)
            {
                Console.WriteLine(strings[i]);
            }
        }
    }
}