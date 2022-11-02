using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Stack<T>
    {
        private Element<T> _head;

        /// <summary>
        /// Property returns number of elements
        /// </summary>
        public int Lenth { get; private set; }

        /// <summary>
        /// Adds obj at the top of the stack
        /// </summary>
        /// <param name="value"></param>
        public void Push(T value)
        {
            Element<T> newElement = new Element<T>() { Data = value };

            newElement.Next = _head;
            _head = newElement;

            Lenth++;
        }

        /// <summary>
        /// Returns top element of stack & removes it
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public Element<T> Pop()
        {
            Element<T> currentElement;
            currentElement = _head;
            _head = currentElement.Next;
            Lenth--;

            return currentElement;
        }

        /// <summary>
        /// Clear stack
        /// </summary>
        public void Clear()
        {
            while (_head != null)
            {
                Pop();
            }
            Console.WriteLine("Stack is Clear");
        }

        /// <summary>
        /// Returns top element but doesn't remove it
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public Element<T> Peek()
        {
            if (_head.Next == null)
            {
                throw new NullReferenceException();
            }
            return _head.Next;
        }

        /// <summary>
        /// Copies stack to array
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public Element<T>[] CopyTo(Element<T>[] elements)
        {
            if (elements.Length < 0)
            {
                throw new IndexOutOfRangeException();
            }

            Element<T> element = null;
            Element<T> currentElement = _head;
            for (int i = 0; i < elements.Length && i != this.Lenth; i++)
            {
                elements[i] = currentElement;
                element = currentElement;
                currentElement = _head.Next;
            }
            return elements;
        }
    }
}
