using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Book
    {
        private Author bookAuthor;
        private string bookTitle;
        private string bookDescription;
        private string[] bookContent;

        public Book (Author bookAuthor, string bookTitle, string bookDescription, string[] bookContent)
        {
            this.bookAuthor = bookAuthor;
            this.bookTitle = bookTitle;
            this.bookDescription = bookDescription;
            this.bookContent = bookContent;
        }


        public string BookTitle { get { return bookTitle; } }
        public string BookAuthor { get { return bookAuthor.FullName; } }

        public string BookInfoShort()
        {
            return $"Author Name: {bookAuthor.FullName} Book Title: {bookTitle}";       
        }


        public void BookInfoFull()
        {
            Console.WriteLine($"Author Name: {bookAuthor.FullName}");
            Console.WriteLine($"Author Biography: {bookAuthor.ShortBiography}");
            Console.WriteLine($"Book Title: {bookTitle}");
            Console.WriteLine($"Book Description: {bookDescription}");
            Console.WriteLine($"book Content:");

            foreach (var item in bookContent)
            {
                Console.WriteLine(item);
            }
        }




    }
}
