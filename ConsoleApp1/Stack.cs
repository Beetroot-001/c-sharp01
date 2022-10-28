using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Stack<T>
    {
        private Node<T>? _Top;

        public int Count { get; private set; }

        public Stack()
        {
            _Top = null;
            Count = 0;
        }

        public void Push(T item)
        {
            var newNode = new Node<T>(item, _Top);
            _Top = newNode;
            Count++;
        }

        public T Pop()
        {
            var res = _Top is not null ? _Top.Data : throw new Exception("Stack is enmty");
            Count--;
            _Top = _Top.Prev;
            return res;
        }

        public void Clear()
        {
            _Top = null;
            Count = 0;
        }

        public T? Peek()
        {
            return _Top is not null ? _Top.Data : throw new Exception("Stack is enmty");
        }

        public void CopyTo(T[] arr)
        {
            int index = 0;
            Node<T> node = _Top;
            arr = new T[Count];
            while (node is not null)
            {
                arr[index++] = node.Data;
                node = node.Prev;
            }
        }
    }
}
