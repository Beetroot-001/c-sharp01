using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ReaderCard
    {
        int _ID;
        Reader _Reader;
        public Book[] ReadBooks;

        public ReaderCard()
        {
            _ID = 0;
            _Reader = new Reader();
            ReadBooks = new Book[0];
        }

        public ReaderCard(int iD, Reader reader, Book[] readBooks)
        {
            _ID = iD;
            _Reader = reader;
            ReadBooks = readBooks;
        }

        public ReaderCard(int iD, Reader reader)
        {
            _ID=iD;
            _Reader=reader;
            ReadBooks=new Book[0];
        }

        public int ID 
        { 
            get => _ID; 

            set => _ID = value;
        }

        public Reader Reader
        {
            get => _Reader;

            set => _Reader = value ?? throw new ArgumentException("Argument can`t be null");
        }
    }
}
