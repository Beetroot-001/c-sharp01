using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Chapter
    {
        public string Title { get; set; }

        public string Description { get; set; } = "";

        public string ShortDescription { get; set; } = "";    
        
        public Chapter(string title)
        {
            Title = title;
        }
        public Chapter(string title, string description) : this(title)
        {
            Description = description;
        }
        public Chapter(string title, string description, string shortDescription) :this(title,description)
        {
            ShortDescription = shortDescription;
        }
    }
}
