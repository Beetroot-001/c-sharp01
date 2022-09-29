using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Book
    {
        private string _title;
        private string _type;
        private string _description;
        private Author _author;
        private DateTime _dateOfPublish;

        public Book (string title, string type, string description, 
            Author author, DateTime dateOfPublish)
        {
            _title = title;
            _type = type;
            _description = description;
            _author = author;
            _dateOfPublish = dateOfPublish;
            _author.BookWritten += 1;
        }

        public void DisplayBookInfo()
        {
            Console.WriteLine("Book info: ");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Description: {Desc}");
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"Publish Date: {PublishDate}");
            Console.WriteLine();
        }

        public string Title { get { return _title; } }
        public string Type { get { return _type; } }
        public string Desc { get { return _description; } }
        public Author Author { get { return _author; } }
        public bool Borrowed { get; set; }
        public DateTime PublishDate { 
            get { return _dateOfPublish; } 
            set { _dateOfPublish = value; } 
        } 
        
    }
}
