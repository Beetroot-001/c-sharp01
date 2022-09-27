namespace ConsoleApp1
{
    internal  class Author
    {
        public string AuthorFirstName {get; set;}
        public string AuthorLastName {get; set;} 
        public string AuthorMiddleName { get; set; }
        public string Pseydonim { get; set; }

        public string WriteNewBook()
        {
            return ("Book name");
        }

        public Author(string authorFirstName, string authorLastName, string authorMiddleName)
        {
            AuthorFirstName = authorFirstName;
            AuthorLastName = authorLastName;
            AuthorMiddleName = authorMiddleName;
        }   

        public Author(string authorFirstName, string authorLastName, string authorMiddleName, string pseydonim) : this(authorFirstName, authorLastName, authorMiddleName)
        {
            Pseydonim = pseydonim;
        }   

        public Author (string pseydonim) 
        { 
            this.Pseydonim = pseydonim; 
        }
    }
}
