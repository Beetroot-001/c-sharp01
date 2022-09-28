using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ReaderCardInfo
    {
        public int CardNumber { get; set; }
        public Reader Reader { get; set; }
        public string[] AlreadyReadBooks { get; set; }
        public string[] BorrowedBooksNow { get; set; }

        public ReaderCardInfo(int cardNumber, Reader reader, string[] alreadyReadBooks, string[] borrowedBooksNow)
        {
            CardNumber = cardNumber;
            Reader = reader;
            AlreadyReadBooks = alreadyReadBooks;
            BorrowedBooksNow = borrowedBooksNow;
        }
    }
}
