using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Book
    {
        public Guid id { get; } = Guid.NewGuid();

        public Author Author { get; set; }

        public string Title { get; set; }

        public string Description { get; set; } = "";

        public List<Chapter> Chapters { get; set; } = new List<Chapter>();

        public Book(Author author, string title)
        {
            Author = author;
            Title = title;
            
        }
        public Book(Author author, string title, List<Chapter> chapters) : this(author, title)
        {
            Chapters = chapters;
        }

        public Book(Author author, string title, string description) : this(author, title)
        {
            Description = description;
        }

        public Book(Author author, string title, string description, List<Chapter> chapters) : this(author, title, description)
        {
            Chapters = chapters;
        }

    }
}
