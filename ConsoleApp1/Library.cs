using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Library
    {
        public string Title { get; set; }

        public string Address { get; set; } = "";

        public string Description { get; set; } = "";

        public enum JobStatus
        {
            AllredyExist,
            Done
        }

        public List<Book> Books { get; set; } = new List<Book>();

        public List<UserCard> UserCards { get; set; } = new List<UserCard>();

        public Library(string title)
        {
            Title = title;
        }

        public Library(string title, List<Book> books, List<UserCard> userCards) : this(title)
        {
            Books = books;
            UserCards = userCards;
        }

        public UserCard CreateNewUserCard(User user)
        {
            var userCard = new UserCard(user);
            UserCards.Add(userCard);
            return userCard;
        }

        public JobStatus AddNewBook(Book book)
        {
            if (!Books.Contains(book)) { Books.Add(book); return JobStatus.Done; }
            else return JobStatus.AllredyExist;
        } 
        
        public void AddNewBookToUser(Book book, UserCard userCard)
        {
            if (!UserCards.Contains(userCard))
            {
                UserCards.Add(userCard);
            }

            userCard.GotBooks.Add(book);
        }

        public void RemoveBookFromUser(Book book, UserCard userCard)
        {
            if (userCard.GotBooks.Contains(book)) { userCard.GotBooks.Remove(book); }
        }

        public JobStatus AddBookToUserCard(UserCard userCard, Book book)
        {
            if (!userCard.GotBooks.Contains(book)) { userCard.GotBooks.Add(book); return JobStatus.Done; }
            else { return JobStatus.AllredyExist; }
        }

        static public void CreateTempBooks(Library library)
        {
            for(int i = 0; i < 10; i++)
            {
                Author author = new Author($"F{i}", $"L{i}", $"M{i}");
                for (int j = 0; j < new Random().Next(10); j++)
                {
                    List<Chapter> chapters = new List<Chapter>();
                    for (int l = 0; l < new Random().Next(5, 10); l++)
                    {
                        Chapter chapter = new Chapter($"A{1} B{j} CH{l}");
                        chapters.Add(chapter);
                    }
                    Book book = new Book(author, $"{author.FirstName} B{j}", $"B_besc{j}", chapters);
                    library.Books.Add(book);
                }
            }
        }

        static public void CreateTempUserCards(Library library)
        {
            for (int j = 0; j < new Random().Next(10, 50); j++)
            {
                User user = new User($"F{1}", $"L{1}", $"M{1}");
                UserCard userCard = new UserCard(user);
                library.UserCards.Add(userCard);
            }
        }

    }
}
