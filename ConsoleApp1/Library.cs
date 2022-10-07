using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Library
    {
        Book[] Books;
        ReaderCard[] Cards;

        public Library()
        {
            Books = new Book[0];
            Cards = new ReaderCard[0];
        }

        public Library(Book[] books, ReaderCard[] cards)
        {
            Books = books;
            Cards = cards;
        }

        public int SearchBook(string name)
        {
            for (int i = 0; i < Books.Length; i++)
            {
                if (Books[i].Name == name)
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
                searchRes = Books[index];
                return true;
            }

            return false;
        }

        public void AddBook(Book newBook)
        {
            if (SearchBook(newBook.Name) == -1)
            {
                BooksRescale(Books.Length + 1);

                Books[Books.Length - 1] = newBook;
            }
            else throw new Exception("try add existing book");
        }

        public void DeleteBook(string name)
        {
            int index = SearchBook(name);
            if (index > -1)
            {
                for(int i = index; i < Books.Length - 1; i++)
                {
                    Books[i] = Books[i + 1];
                }
            }

            if (index > -1)
            {
                BooksRescale(Books.Length - 1);
            }
        }

        public int SearchReaderCard(int iD)
        {
            for (int i = 0; i < Cards.Length; i++)
            {
                if (Cards[i].ID == iD)
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
                CardsRescale(Cards.Length + 1);

                Cards[Cards.Length - 1] = newCard;
            }
            else throw new Exception("try add existing book");
        }

        public void DeleteReaderCard(int iD)
        {
            int index = SearchReaderCard(iD);
            if (index > -1)
            {
                for (int i = index; i < Cards.Length - 1; i++)
                {
                    Cards[i] = Cards[i + 1];
                }
            }

            if (index > -1)
            {
                CardsRescale(Cards.Length - 1);
            }
        }

        private void BooksRescale(int newLength)
        {
            Book[] temp = new Book[newLength];

            for (int i = 0; i < temp.Length && i < Books.Length; i++)
            {
                temp[i] = Books[i];
            }

            Books = temp;
        }

        private void CardsRescale(int newLength)
        {
            ReaderCard[] temp = new ReaderCard[newLength];

            for (int i = 0; i < temp.Length && i < Cards.Length; i++)
            {
                temp[i] = Cards[i];
            }

            Cards = temp;
        }
    }
}
