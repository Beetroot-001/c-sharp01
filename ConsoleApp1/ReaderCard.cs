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
        private int _iD;
        private Reader _reader;
        public Book[] ReadBooks;

        public ReaderCard()
        {
            _iD = 0;
            _reader = new Reader();
            ReadBooks = new Book[0];
        }

        public ReaderCard(int iD, Reader reader, Book[] readBooks)
        {
            _iD = iD;
            _reader = reader;
            ReadBooks = readBooks;
        }

        public ReaderCard(int iD, Reader reader)
        {
            _iD=iD;
            _reader=reader;
            ReadBooks=new Book[0];
        }

        public int ID 
        { 
            get => _iD; 
            set => _iD = value;
        }

        public Reader Reader
        {
            get => _reader;
            set => _reader = value ?? throw new ArgumentException("Argument can`t be null");
        }
    }
}
