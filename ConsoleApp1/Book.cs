using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Book
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Author Writer { get; set; }
        public int PagesCount { get; set; }

        public string[] Chapters { get; set; }

        public Book(string title, string description, Author author, int pagesCount, params string[] chapters)
        {
            Title = title;
            Description = description;
            Writer = author;
            PagesCount = pagesCount;
            Chapters = chapters;
        }
    }
}
