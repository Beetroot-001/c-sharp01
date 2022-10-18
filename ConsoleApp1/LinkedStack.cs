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

    public class LinkedStack<T>
    {
        ListElement<T> _head;        
        public void Push(T value)
        {
            ListElement<T> element = new ListElement<T>();            
            element.Data = value;            
            element.Next = _head;            
            _head = element;
            
        }

        public T Pop()
        {
            if (_head == null) { throw new ArgumentNullException(); }
            else
            {
                T temp = _head.Data;
                _head = _head.Next;
                return temp;
            }
        }

        public T Peak()
        {
            return _head.Data;
        }

        public void Clear()
        {
            _head = null;
        }

        public void CopyTo(T[] values)
        {
            var element = _head;
            try
            {
                while (element.Next != null)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = element.Data;
                        element = element.Next;
                    }
                }
            }
            catch(NullReferenceException nul)
            {
                throw new Exception("Array outranges the stack!", nul);
            }
        }

    }
}
