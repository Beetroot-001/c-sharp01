namespace ConsoleApp1

{
    internal class Book
    {
        public Author AuthorOfBook { get; set; }
        public string BookName { get; set; }    
        public string Description { get; set; }
        public string[] Chapter { get; set; }
        public int TotalPages { get; set; }
        public bool Pictures { get; set; }
        public bool IsInTheLibraryNow { get; set; }
        public static  int HowManyCopiesInTotal { get; set; }
        public DateTime WhenNeedToBeReturnedToTheLibrary { get; set; }
        public static bool IsFoud { get; set; }

        public Book(Author authorOfBook, string bookName, string description, string[] chapter, int totalPages, bool pictures, DateTime whenNeedToBeReturnedToTheLibrary, bool iSInTheLibraryNow = false, int howManyCopiesInTotal = 0)
        {
            AuthorOfBook = authorOfBook;
            BookName = bookName;
            Description = description;
            Chapter = chapter;
            TotalPages = totalPages;
            Pictures = pictures;
            IsInTheLibraryNow = iSInTheLibraryNow;
            HowManyCopiesInTotal = howManyCopiesInTotal;
            WhenNeedToBeReturnedToTheLibrary = whenNeedToBeReturnedToTheLibrary;
        }


        public  void ReedBook()
        {

        }

        public static bool FindBook(Book bookName, Author firstName, Author lastName)
        {
            return IsFoud;
;       }
    }
}
