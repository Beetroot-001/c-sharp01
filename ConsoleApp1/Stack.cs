namespace ConsoleApp1
{
    class Stack<T>
    {
        // top
        private Node<T> _top;
        private int _size;
        public int Count => _size;
        public bool IsEmpty => _top == null;

        public Stack()
        {
            _top = null;
            _size = 0;
        }
        // push
        public void Push(T newData)
        {
            var toInsert = new Node<T>(newData);

            if (_top == null)
            {
                _top = toInsert;
            }
            else
            {
                toInsert.Next = _top;
                _top = toInsert;
            }
            _size++;
        }
        // pop
        public T Pop()
        {
            if (IsEmpty)
            {
                Console.WriteLine("Stack is empty!");
                return default(T);
            }
            var data = _top.Data;
            _top = _top.Next;
            _size--;
            return data;
        }
        public void Clear()
        {
            _top = null;
            _size = 0;
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                Console.WriteLine("Stack is empty!");
                return default(T);
            }
            var data = _top.Data;
            return data;
        }

        public void CopyTo(T[] array)
        {
            if (IsEmpty)
            {
                Console.WriteLine("No elements to copy");
                return;
            }
            var currentData = _top;
            for (int i = 0; i < array.Length && i < _size; i++)
            {
                array[i] = currentData.Data;
                currentData = currentData.Next;
            }
        }

        public void Display()
        {
            Console.WriteLine("Stack elements: ");
            if (IsEmpty)
            {
                Console.WriteLine("No elements to display");
                return;
            }
            var currentData = _top;
            for (int i = 0; i < _size; i++)
            {
                Console.WriteLine(currentData.Data.ToString());
                currentData = currentData.Next;
            }
        }
    }
}