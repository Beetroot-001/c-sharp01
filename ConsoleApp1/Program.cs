using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> testStack = new Stack<int>();
            testStack.Push(3);
            testStack.Push(1);
            testStack.Push(2);
            testStack.Push(10);
            testStack.Display();

            Console.WriteLine(testStack.Pop().ToString());
            Console.WriteLine(testStack.Peek().ToString());
            Console.WriteLine(testStack.Pop().ToString());
            Console.WriteLine(testStack.Pop().ToString());
            Console.WriteLine(testStack.Pop().ToString());
            Console.WriteLine(testStack.Pop().ToString());

            testStack.Display();

            Queue<string> testQueue = new Queue<string>();
            testQueue.Display();
            testQueue.Dequeue();

            testQueue.Enqueue("test1");
            testQueue.Enqueue("test2");
            testQueue.Enqueue("test3");

            testQueue.Dequeue();

            testQueue.Display();
            testQueue.Dequeue();
            testQueue.Dequeue();
            testQueue.Display();

            Stack<TestClass> classTestStack = new Stack<TestClass>();

            var data = classTestStack.Pop();
            Console.WriteLine(data);
        }
    }
    class TestClass
    {
        public int Value { get; set; }

        public TestClass()
        {
            Value = 1;
        }
    }
}