using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Book
    {
        private string _bookInfo;
        private Author _author;
        private string _name;
        private string _description;
        public string[] Chapters;

        public Book()
        {
            _bookInfo = string.Empty;
            _author = new Author();
            _name = string.Empty;
            _description = string.Empty;
            Chapters = new string[0];
        } 

        public Book(string bookInfo, Author author, string name, string description, string[] chapters)
        {
            _bookInfo = bookInfo;
            _author = author;
            _name = name;
            _description = description;
            Chapters = chapters;
        }

        public string BookInfo
        {
            get => _bookInfo;
            set => _bookInfo = value ?? throw new ArgumentException("Argument can`t be null");
        }

        public Author Author 
        {
            get => _author;
            set => _author = value ?? throw new ArgumentException("Argument can`t be null");
        }

        public string Name
        { 
            get => _name; 
            set => _name = value ?? throw new ArgumentException("Argument can`t be null");
        }

        public string Description
        {
            get => _description;
            set => _description = value ?? throw new ArgumentException("Argument can`t be null");
        }
    }
}
