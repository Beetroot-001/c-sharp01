using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Stack<T>
    {
        private object[] objects;
        private Type[] types;
        private int counter;
        public void Push(T obj)
        {
            Array.Resize(ref objects, counter + 1);
            Array.Resize(ref types, counter + 1);
            types[counter] = typeof(T);
            objects[counter] = obj;
            counter++;
        }
        public T Pop()
        {            
            T res = (T)Convert.ChangeType(objects[counter - 1], types[counter - 1]);
            counter--;
            Array.Resize(ref objects, counter + 1);
            Array.Resize(ref types, counter + 1);
            Console.WriteLine("POP");
            return res;
        }
        public void Clear()
        {
            int counter = 0;
            Array.Clear(objects);
            Array.Clear(types);
        }
        public int Count()
        {
            Console.WriteLine("COUNT");
            return counter;
        }
        public T Peek()
        {
            Console.WriteLine("PEEK");
            return (T)Convert.ChangeType(objects[counter - 1], types[counter - 1]);
        }
        public void CopyTo(ref T[] values)
        {
            Console.WriteLine("COPYTO");
            T[] temp = null;
            Array.Resize(ref values, counter);
            for (int i = 0; i < counter; i++)
            {
                values[i] = (T)Convert.ChangeType(objects[i], types[i]);
            }

        }
    }
}
