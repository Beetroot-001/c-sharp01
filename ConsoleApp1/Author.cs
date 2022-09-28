using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
     class Author
    {
        private string fullName;
        private string shortBiography;

        public Author(string fullName, string description)
        {
            this.fullName = fullName;
            this.shortBiography = description;
        }

        public string FullName {get {return fullName;}}
        public string ShortBiography { get {return shortBiography;}}

    }
}
