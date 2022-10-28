using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Node<T>
    {
        public T Data;
        public Node<T>? Prev;

        public Node(T data)
        {
            Data = data;
            Prev = null;
        }

        public Node(T data, Node<T>? prev) : this(data)
        {
            Prev = prev;    
        }
    }
}
