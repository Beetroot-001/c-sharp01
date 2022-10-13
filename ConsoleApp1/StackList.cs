using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    
    
   internal class StackListNode<T>
    {
        public T data;
        public StackListNode <T> next;

        public StackListNode(T data)
        {
            this.data = data;
            next = null;
        }
    }
    
    
    internal class StackList<T>
    {
        StackListNode<T> head;
        int length;

        public StackList()
        {
            head = null;
            length = 0;
        }

        public int Count => length;

        /// <summary>
        /// Add element at the top of the list
        /// </summary>
        /// <param name="value"></param>
        public void Push(T value)
        {
            StackListNode <T> newNode = new StackListNode<T>(value);
            newNode.next = head;
            head = newNode;
            length++;
        }

        /// <summary>
        /// Removes and returns the element at the top of the list
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            T result = Peek();
            head = head.next;
            length--;
            return result;
        }

        /// <summary>
        /// Returns the element at the top of the list
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            T result;                 
            result = head.data;        
            return result;
        }

        /// <summary>
        /// Removes all elements from the list
        /// </summary>
        public void Clear()
        {
            while (head.next != null)
            {
                head = head.next;
            }
            head = null;
            length = 0;
        }

        /// <summary>
        /// Display at console all elements of the list 
        /// </summary>
        public void PrintList()
        {
            StackListNode <T> runner = head;
            while (runner != null)
            {
                Console.WriteLine(runner.data);
                runner = runner.next;
            }
        }

        /// <summary>
        /// Copy all elements of te list to the array
        /// </summary>
        /// <param name="array"></param>
        public void CopyTo(T[] array)
        {
            StackListNode <T> runner = head;

            for (int i = 0; i < array.Length && runner != null; i++)
            {
                array[i] = runner.data;
                runner = runner.next;
            }
        }









    }
}
