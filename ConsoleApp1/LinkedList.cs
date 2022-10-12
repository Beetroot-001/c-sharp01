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

	public class LinkedList<T>
	{
		private ListElement<T> _head;

		public int Length { get; private set; }
		public void Add(T value)
		{
			ListElement<T> newElement = new ListElement<T>
			{
				Data = value
			};

			if (_head == null)
			{
				_head = newElement;
			}
			else
			{
				var currentElement = _head;
				while (currentElement.Next != null)
				{
					currentElement = currentElement.Next;
				}

				currentElement.Next = newElement;
			}

			Length++;
		}


		public T Remove(int position)
		{
			if (position < 0 || position > Length - 1)
			{
				throw new ArgumentOutOfRangeException(nameof(position));
			}

			ListElement<T> elementToRemove = null;

			if (position == 0)
			{
				elementToRemove = _head;
				_head = _head.Next;
			}
			else
			{
				ListElement<T> prevElement = null;
				elementToRemove = _head;
				for (int i = 0; i < position; i++)
				{
					prevElement = elementToRemove;
					elementToRemove = elementToRemove.Next;
				}

				prevElement.Next = elementToRemove.Next;
			}

			Length--;
			return elementToRemove.Data;
		}

		public void Insert(int position, T data)
		{
			if (position < 0 || position > Length)
			{
				throw new ArgumentOutOfRangeException(nameof(position));
			}

			var newElement = new ListElement<T>()
			{
				Data = data
			};

			if (position == 0)
			{
				newElement.Next = _head;
				_head = newElement;
			}
			else
			{
				ListElement<T> prevElement = null;
				var currentElement = _head;

				for (int i = 0; i < position; i++)
				{
					prevElement = currentElement;
					currentElement = currentElement.Next;
				}

				prevElement.Next = newElement;
				newElement.Next = currentElement;
			}

			Length++;
		}

		public T GetByIndex(int position)
		{
			if (position < 0 || position > Length - 1)
			{
				throw new ArgumentOutOfRangeException(nameof(position));
			}

			var currentElement = _head;

			for (int i = 0; i < position; i++)
			{
				currentElement = currentElement.Next;
			}

			return currentElement.Data;
		}

		public T this[int index]
		{
			get => GetByIndex(index);
			set => Insert(index, value);
		}

		public void CopyTo(T[] values)
		{
			var currentElement = _head;
			for (int i = 0; i < values.Length && currentElement != null; i++)
			{
				values[i] = currentElement.Data;
				currentElement = currentElement.Next;
			}
		}

		public T[] ToArray()
		{
			T[] values = new T[Length];
			CopyTo(values);

			return values;
		}
	}

	public class Person
	{
		public string Fullname { get; set; }
	}
}
