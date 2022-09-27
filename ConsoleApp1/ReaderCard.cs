using System.Security.Cryptography;

namespace ConsoleApp1
{
    internal class ReaderCard
    {
        public DateTime CardExpirationDate { get; set; }
        public int BooksNowAreTakenToHome { get; set; }
        public int TakenBooksInTotal { get; set; }
        public int CardNumber { get; set; }

        public ReaderCard(int takenBooksInTotal)
        {
            TakenBooksInTotal = takenBooksInTotal;
        }

        public ReaderCard(DateTime cardExpirationDate, int booksNowAreTakenToHome, int takenBooksInTotal, int cardNumber)
        {
            CardExpirationDate = cardExpirationDate;
            BooksNowAreTakenToHome = booksNowAreTakenToHome;
            TakenBooksInTotal = takenBooksInTotal;
            CardNumber = cardNumber;

        }

        public void AssignCard()
        {

        }

        public  static string GenerateCardNumber(string surnameOfReader)
        {
            Random random = new Random();
            string cardNumber = random.Next(100-200).ToString() + DateTime.Now.ToString();
            return cardNumber;
        }
      
    }
}
