using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Books
    {
        public string Authors { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }// опис
        public int YearOfPublication { get; set; }
        public string[] Content { get; set; } 

        public Books(string authors, string title, string description, int yearOfPublication, string[] content = null)
        {
            this.Authors = authors;
            this.Title = title; 
            this.Description = description??"No information";
            this.Content = content ?? new string[] {"No information"}; 
            this.YearOfPublication = yearOfPublication;
        }

        public void GetFullInformation()
        { 
            Console.WriteLine($"Title: {Title}\tAuthors: {Authors}\tYear Of Publication: {YearOfPublication}\nDescription:\n{Description}\n\n\t\tTable of Content:\n");
            GetContentInformation();
        }

        private void GetContentInformation()
        {
            for (int i = 0; i < Content.Length; i++)
            {
                Console.WriteLine(Content[i]);
            }
            Console.WriteLine();
        }

    }
}
