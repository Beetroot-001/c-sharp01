using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{


    class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AboutInfo { get; set; }


        public Author(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            AboutInfo = "default information about Author";
        }

        public Author(string firstName, string lastName, string about)
        {
            FirstName = firstName;
            LastName = lastName;
            AboutInfo = about;
        }

        public string DisplayName()
        {
            return FirstName + " " + LastName;
        }
    }
}
