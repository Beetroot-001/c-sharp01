namespace ConsoleApp1
{
    class Queue<T>
    {
        // head
        Node<T> _head;
        Node<T> _tail;
        int _size;

        public int Count => _size;
        public bool IsEmpty => _head == null ? true : false;

        public Queue()
        {
            _head = _tail = null;
            _size = 0;
        }
        // enqueue
        public void Enqueue(T newData)
        {
            var toInsert = new Node<T>(newData);

            if (IsEmpty)
            {
                _head = _tail = toInsert;

            }
            else if (_size == 1)
            {
                _tail = toInsert;
                _head.Next = _tail;
            }
            else
            {
                _tail.Next = toInsert;
                _tail = _tail.Next;
            }
            _size++;
        }
        // dequeue
        public T Dequeue()
        {
            if (IsEmpty)
            {
                Console.WriteLine("Queue is empty!");
                return default(T);
            }
            else if (_size == 1)
            {
                var data = _head.Data;
                _head = _tail = null;
                _size--;
                return data;
            }
            else
            {
                var data = _head.Data;
                _head = _head.Next;
                _size--;
                return data;
            }
        }
        public void Clear()
        {
            _head = _tail = null;
            _size = 0;
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                Console.WriteLine("Queue is empty!");
                return default(T);
            }
            var data = _head.Data;
            return data;
        }

        public void CopyTo(T[] array)
        {
            if (IsEmpty)
            {
                Console.WriteLine("No elements to copy");
                return;
            }
            var currentData = _head;
            for (int i = 0; i < array.Length && i < _size; i++)
            {
                array[i] = currentData.Data;
                currentData = currentData.Next;
            }
        }
        public void Display()
        {
            Console.WriteLine("Queue elements: ");
            if (IsEmpty)
            {
                Console.WriteLine("No elements to display");
                return;
            }
            var currentData = _head;
            for (int i = 0; i < _size; i++)
            {
                Console.WriteLine(currentData.Data.ToString());
                currentData = currentData.Next;
            }
        }
    }
}