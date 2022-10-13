using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Library
    {
        private Book[] _books;
        private ReaderCard[] _cards;

        public Library()
        {
            _books = new Book[0];
            _cards = new ReaderCard[0];
        }

        public Library(Book[] books, ReaderCard[] cards)
        {
            _books = books;
            _cards = cards;
        }

        public int SearchBook(string name)
        {
            for (int i = 0; i < _books.Length; i++)
            {
                if (_books[i].Name == name)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool SearchBook(string name, ref Book searchRes)
        {   
            int index = SearchBook(name);
            if (index > -1)
            {
                searchRes = _books[index];
                return true;
            }

            return false;
        }

        public void AddBook(Book newBook)
        {
            if (SearchBook(newBook.Name) == -1)
            {
                BooksRescale(_books.Length + 1);

                _books[_books.Length - 1] = newBook;
            }
            else throw new Exception("try add existing book");
        }

        public void DeleteBook(string name)
        {
            int index = SearchBook(name);
            if (index > -1)
            {
                for(int i = index; i < _books.Length - 1; i++)
                {
                    _books[i] = _books[i + 1];
                }
            }

            if (index > -1)
            {
                BooksRescale(_books.Length - 1);
            }
        }

        public int SearchReaderCard(int iD)
        {
            for (int i = 0; i < _cards.Length; i++)
            {
                if (_cards[i].ID == iD)
                {
                    return i;
                }
            }

            return -1;
        }

        public void AddReaderCard(ReaderCard newCard)
        {
            if (SearchReaderCard(newCard.ID) == -1)
            {
                CardsRescale(_cards.Length + 1);

                _cards[_cards.Length - 1] = newCard;
            }
            else throw new Exception("try add existing book");
        }

        public void DeleteReaderCard(int iD)
        {
            int index = SearchReaderCard(iD);
            if (index > -1)
            {
                for (int i = index; i < _cards.Length - 1; i++)
                {
                    _cards[i] = _cards[i + 1];
                }
            }

            if (index > -1)
            {
                CardsRescale(_cards.Length - 1);
            }
        }

        private void BooksRescale(int newLength)
        {
            Book[] temp = new Book[newLength];

            for (int i = 0; i < temp.Length && i < _books.Length; i++)
            {
                temp[i] = _books[i];
            }

            _books = temp;
        }

        private void CardsRescale(int newLength)
        {
            ReaderCard[] temp = new ReaderCard[newLength];

            for (int i = 0; i < temp.Length && i < _cards.Length; i++)
            {
                temp[i] = _cards[i];
            }

            _cards = temp;
        }
    }
}
