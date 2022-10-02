using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Books
    {
        public string authors { get; set; }
        public string title { get; set; }
        public string description { get; set; }// опис
        public int yearOfPublication { get; set; }
        public string[] content { get; set; } 

        public Books(string authors, string title, string description, int yearOfPublication, string[] content = null)
        {
            this.authors = authors;
            this.title = title; 
            this.description = description??"No information";
            this.content = content ?? new string[] {"No information"}; 
            this.yearOfPublication = yearOfPublication;
        }

        public void GetFullInformation()
        { 
            Console.WriteLine($"Title: {title}\tAuthors: {authors}\tYear Of Publication: {yearOfPublication}\nDescription:\n{description}\n\n\t\tTable of Content:\n");
            GetContentInformation();
        }

        private void GetContentInformation()
        {
            for (int i = 0; i < content.Length; i++)
            {
                Console.WriteLine(content[i]);
            }
            Console.WriteLine();
        }

    }
}
