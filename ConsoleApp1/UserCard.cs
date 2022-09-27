using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class UserCard
    {
        public Guid Id { get; } = Guid.NewGuid();

        public User User { get; set; }

        public List<Book> GotBooks { get; set; } = new List<Book>();

        public UserCard(User user)
        {
            this.User = user;
        }

        public void GetBook(Book book)
        {
            GotBooks.Add(book);
        }

        public void RomoveBook(Book book)
        {
            if (GotBooks.Contains(book)) { GotBooks.Remove(book); }
        }
    }
}
