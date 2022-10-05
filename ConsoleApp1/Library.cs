using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Library
    {
        public Book[]? books;
        private Ticket[]? tickets;
        private int bookCount = 0;
        private int ticketsCount = 0;

        public void AddBook(Book book)
        {
            Array.Resize(ref books, bookCount + 1);
            books[bookCount] = book;
            bookCount++;
        }

        public void DeleteBook(Book book)
        {
            DeleteRecord(books, book);
        }

        public void ShowLibrary()
        {
            foreach (Book book in books)
            {
                Console.WriteLine(book.name + " " + book.writerName);
            }
        }

        public void SearchBook()
        {
            string input = Console.ReadLine() ?? string.Empty;
            foreach (Book book in books)
            {
                if (book.name.Contains(input, StringComparison.OrdinalIgnoreCase) || book.writerName.Contains(input, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(bookCount + " " + book.name + " " + book.writerName);
                }
            }
        }

        public void AddTicket(Reader reader)
        {
            ticketsCount++;
            Array.Resize(ref tickets, ticketsCount);
            Ticket ticket = new Ticket(reader);
            ticket.Id = ticketsCount;
            tickets[ticketsCount - 1] = ticket;
        }

        public void DeleteTicket(Reader reader)
        {

            DeleteRecord(tickets, GetTicketByReader(reader));
        }

        public void ViewTickets()
        {
            foreach (Ticket ticket in tickets)
            {
                Console.WriteLine(ticket.Id + " " + ticket.Name);
            }
        }

        private void DeleteRecord(Book[] bookList, object obj)
        {
            for (int i = 0; i < bookList.Length - 1; i++)
            {
                if (bookList[i] == obj && obj != bookList[bookList.Length - 1])
                {
                    Book temp = bookList[bookList.Length - 1];
                    bookList[i] = temp;
                    Array.Resize(ref books, bookList.Length - 1);

                }
                else
                {
                    Array.Resize(ref bookList, bookList.Length - 1);
                }
            }
        }
        private void DeleteRecord(Ticket[] ticketList, object obj)
        {
            for (int i = 0; i < ticketList.Length - 1; i++)
            {
                if (ticketList[i] == obj && obj != ticketList[ticketList.Length - 1])
                {
                    Ticket temp = ticketList[ticketList.Length - 1];
                    ticketList[i] = temp;
                    Array.Resize(ref tickets, ticketList.Length - 1);

                }
                else
                {
                    Array.Resize(ref ticketList, ticketList.Length - 1);
                }
            }
        }

        public void GetBook(Book book, Ticket ticket)
        {
            if (book.isReadNow == false)
            {
                foreach (Book book2 in books)
                {
                    if (book2 == book)
                    {
                        ticket.AddBookToReadList(book);
                        Console.WriteLine("Book was successfully taken!");
                    }

                }
            }
            else
            {
                Console.WriteLine("Book is unavailable now, please try later!");
            }
            book.isReadNow = true;
        }

        public Ticket GetTicketByReader(Reader reader)
        {
            Ticket ticket1 = null;
            try
            {
                foreach (Ticket ticket in tickets)
                {
                    if (reader.name == ticket.Name)
                    {
                        ticket1 = ticket;
                    }
                }
            }
            catch (ArgumentNullException argNull) { throw new Exception("No such reader found!", argNull); }
            return ticket1;
        }
        public void LookHistory(Reader reader)
        {
            Ticket ticket = GetTicketByReader(reader);
            ticket.ReadList();

        }
    }
}
