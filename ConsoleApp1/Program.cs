namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedStack<int> ints = new LinkedStack<int>();
            ints.Push(1);
            ints.Push(2);
            ints.Push(3);            
            int[] ints1 = new int[3];
            ints.CopyTo(ints1);
        }
    }
}