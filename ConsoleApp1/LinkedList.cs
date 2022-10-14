using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    ////////It's my test list that I used to train. Never mind. Pls, take a look at StackList
    internal class LinkedListNode 
    {
        public int data;
        public LinkedListNode next;

        public LinkedListNode(int data)
        {
            this.data = data;
            next = null;
        }
    }

    internal class LinkedList
    {
        LinkedListNode head;
        int length;

        //LinkedListNode first;

        public LinkedList()
        {
            head = null;
            length = 0;
        }

        //public void AddNoteToBack(int value)
        //{
        //    LinkedListNode newNode = new LinkedListNode(value);

        //    if (head == null)
        //    {
        //        head = newNode;
        //        first = head;
        //    }
        //    else
        //    {
        //        head.next = newNode;
        //        head = newNode;
        //    }

        //    length++;
        //}

        public int Count => length;

        public void Push(int value)
        {
            LinkedListNode newNode = new LinkedListNode(value);
            newNode.next = head;
            head = newNode;
            length++;
        }

        public int Pop()
        {
            int result = Peek();
            head = head.next;
            length--;
            return result;
        }

        public int Peek()
        {
            return head.data;
        }


        public void Clear()
        {
            while (head.next != null )
            {
                head = head.next;
            }
            head = null;
            length = 0;  
        }


        public void PrintList()
        {          
            LinkedListNode runner = head;
            while (runner != null)
            {
                Console.WriteLine(runner.data);
                runner = runner.next;
            }
        }


        public void CopyTo(int[] array)
        {
            LinkedListNode runner = head;
            
            for (int i = 0; i < array.Length && runner != null; i++)
            {
                  array[i] = runner.data;
                  runner = runner.next;
            } 
        }



        //public void PrintList2()
        //  {
        //      LinkedListNode runner = first;
        //      while (runner != null)
        //      {
        //          Console.WriteLine(runner.data);
        //          runner = runner.next;
        //      }
        //  }

    }
}
