namespace ConsoleApp1
{
    internal class Library
    {
        public Book Books { get; set; }
        public int TotalAmountOfBooksInLibrary { get; set; }
        public Reader Reader { get; set; }
        public int TotalReaderCardsAmount { get; set; }
        public ReaderCard[] ReaderCardsDataBase { get; set; }
        
        //FindBook
        public bool FindBook(Book bookName, Author firstName, Author lastName)
        {
            return Book.FindBook(bookName, firstName, lastName);
        }
        
        //Add book to the library
        public int AddBookToTheLibrary(Book bookName, int HowManyCopiesInTotal)
        {
            bookName.IsInTheLibraryNow = true;
            return TotalAmountOfBooksInLibrary += HowManyCopiesInTotal;
        }

        //Delete book from the library
        public int DeleteBookFromLibrary(Book bookName, int howManyCopiesOfSpecificBookInTotal)
        {
            bookName.IsInTheLibraryNow = false;
            return  TotalAmountOfBooksInLibrary -= howManyCopiesOfSpecificBookInTotal;
        }


        // Add or delete reader card
        public ReaderCard[] AddDeleteReaderCard(ReaderCard[] ReaderCardsDataBase, ReaderCard card, bool addTrueDeleteFalse)
        {
            var cardDataBase = ReaderCardsDataBase.ToList();
            for (int i = 0; i < cardDataBase.Count; i++)
            {
                if (cardDataBase[i].CardNumber == card.CardNumber && addTrueDeleteFalse == false)
                {
                    cardDataBase.Remove(cardDataBase[i]);
                }
                else if (cardDataBase[i].CardNumber != card.CardNumber && addTrueDeleteFalse == true)
                {
                    cardDataBase.Add(cardDataBase[i]);
                }
                else if (cardDataBase[i].CardNumber != card.CardNumber && addTrueDeleteFalse == true)
                {
                    Console.WriteLine("Can't find this card");
                }
            }

            return cardDataBase.ToArray();
        }
    }
}
