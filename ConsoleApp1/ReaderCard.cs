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

        private List<Book> _borrowed;

        private int _limit;

        private DateTime _expDate;

        public ReaderCard(Reader owner, DateTime expDate, int limit)
        {
            this.owner = owner;
            this._borrowed = new List<Book>();
            this._expDate = expDate;
            this._limit = limit;
        }

        public bool AddBook(Book newBook)
        {   
            if (_borrowed.Count + 1 > _limit)
            {
                return false;
            }
            _borrowed.Add(newBook);
            return true;
        }
    }
}
