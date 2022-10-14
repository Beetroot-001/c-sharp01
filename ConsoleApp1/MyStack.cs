using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ListElement<T>
    {
        public T Data { get; set; }
        public ListElement<T> Next { get; set; }
    }

    public class MyStack<T>
    {
        public ListElement<T> top;
        public int Size { get; private set; }

        public void Push(T value)
        {
            ListElement<T> stackElement = new ListElement<T>()
            {
                Data = value,
            };

            if (top == null)
            {
                top = stackElement;
            }
            else
            {
                stackElement.Next = top;
                top = stackElement;
            }

            Size++;
        }
        public T Pop()
        {
            if (top == null)
            {
                throw new Exception("Stack is empty!");
            }
            else
            {
                var temp = top.Data;
                top = top.Next;
                Size--;

                return temp;
            }
        }
        public T Peek()
        {
            if (top == null)
            {
                throw new Exception("Empty stack!");
            }
            else
            {
                return top.Data;
            }
        }
        public int Count()
        {
            return Size;
        }
        public void Clear()
        {
            if (top == null)
            {
                throw new Exception("Already Empty Stack! Nothing to clear");
            }
            else
            {
                Size = 0;
                top = null;

            }
        }
        public void CopyTo(T[] values)
        {
            if (top == null)
            {
                throw new Exception("Nothing to Copy!");
            }
            else
            {
                var currentElement = top;
                for (int i = 0; i < values.Length && i < Size; i++)
                {
                    values[i] = currentElement.Data;
                    currentElement = currentElement.Next;
                }
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }
    }
}
