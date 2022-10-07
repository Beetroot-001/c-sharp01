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
        string _BookInfo;
        Author _Author;
        string _Name;
        string _Description;
        public string[] Chapters;

        public Book()
        {
            _BookInfo = string.Empty;
            _Author = new Author();
            _Name = string.Empty;
            _Description = string.Empty;
            Chapters = new string[0];
        } 

        public Book(string bookInfo, Author author, string name, string description, string[] chapters)
        {
            _BookInfo = bookInfo;
            _Author = author;
            _Name = name;
            _Description = description;
            Chapters = chapters;
        }

        public string BookInfo
        {
            get => _BookInfo;

            set => _BookInfo = value ?? throw new ArgumentException("Argument can`t be null");
        }

        public Author Author 
        { 
            get => _Author;

            set => _Author = value ?? throw new ArgumentException("Argument can`t be null");
        }

        public string Name
        { 
            get => _Name; 
            
            set => _Name = value ?? throw new ArgumentException("Argument can`t be null");
        }

        public string Description
        {
            get => _Description;

            set => _Description = value ?? throw new ArgumentException("Argument can`t be null");
        }
    }
}
