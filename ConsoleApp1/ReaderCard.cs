using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ReaderCard
    {
        public Reader owner;

        private Book[] _borrowed;

        private int _limit;

        private DateTime _expDate;

        public ReaderCard(Reader owner, DateTime expDate, int limit)
        {
            this.owner = owner;
            this._borrowed = new Book[1];
            this._expDate = expDate;
            this._limit = limit;
        }

        public void DisplayBooks()
        {
            for (int i = 0; i < _borrowed.Length - 1; i++)
            {
                Console.WriteLine($"Book #{i}");
                _borrowed[i].DisplayBookInfo();
                _borrowed[i].Author.DisplayAuthorInfo();
            }
        }

        public bool AddBook(Book newBook)
        {   
            if (_borrowed.Length + 1 > _limit || _expDate < DateTime.Today)
            {
                return false;
            }
            newBook.Borrowed = true;
            _borrowed[^1] = newBook;
            Array.Resize(ref _borrowed, _borrowed.Length + 1);
            
            return true;
        }

        public int SearchBook(string title)
        {   
            for (int i = 0; i < _borrowed.Length; i++)
            {
                if (_borrowed[i].Title == title)
                {
                    return i;
                }
            }
            return -1;
        }
        public Book ReturnBook(string title) 
        {
            int index = SearchBook(title);
            Book temp = _borrowed[index];
            temp.Borrowed = false;
            if (index == -1)
            {
                return null;
            }
            else if (_borrowed.Length == 1)
            {
                _borrowed = new Book[1];
                return temp;
            }
            Book[] newArray = new Book[_borrowed.Length - 1];
            for (int i = 0, j = 0; i < _borrowed.Length; i++, j++)
            {
                if (i == index)
                {
                    i++;
                }
                newArray[j] = _borrowed[i];
            }
            _borrowed = newArray;
            return temp;
        }
    }
}
