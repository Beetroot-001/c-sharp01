using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    internal class Library
    {

        public Book[] Books { get; set; } =
            { new Book
                ("Kobzar",
                "The first collection of works by the prominent Ukrainian poet and artist Taras Shevchenko",
                new ("Taras", "Shevchenko"),
                624,
                new string[]{"Introduction", "Manual", "Outro" })
            };
        public ReaderCardInfo[] readerCardsInfos { get; set; }


        public Book SearchBook(string input)
        {
            bool intChecker = int.TryParse(input, out int count);

            for (int i = 0; i < Books.Length; i++)
            {
                if (Books[i].Title.ToLowerInvariant().Trim().Contains(input) ||
                    Books[i].Description.ToLowerInvariant().Trim().Contains(input) ||
                    Books[i].Writer.FirstName.ToLowerInvariant().Trim().Contains(input) ||
                    Books[i].Writer.LastName.ToLowerInvariant().Trim().Contains(input) ||
                    Books[i].PagesCount == count)
                {
                    return Books[i];
                }
            }
            return null;




        }
        public Book[] AddBook(Book book, int amount)
        {
            
            Book[] common = new Book[Books.Length + amount];
            Book[] newBookArray = new Book[amount];
            Array.Fill(newBookArray, book);
            Array.Copy(Books, 0, common, 0, Books.Length);
            //Array.Copy(Books, common, Books.Length);

            Array.Copy(newBookArray, 0, common, Books.Length, amount);
            Books = common;
            return Books;
        }

        public Book[] DeleteBook(string input, Book[] books)
        {
            try
            {
                Book result = SearchBook(input);
                int index = Array.IndexOf(Books, result);


                Book[] resultArray = new Book[Books.Length - 1];

                int i = 0;
                int j = 0;
                while (i < Books.Length)
                {
                    if (i != index)
                    {
                        resultArray[j] = Books[i];
                        j++;
                    }
                    i++;

                }
                Array.Resize(ref books, resultArray.Length);
                Books = resultArray;
                return Books;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine();
                Console.WriteLine("Not found books by your criteria");
                Console.WriteLine();
                return Books;
            }


        }

        public void DisplayAllAvailableBooksList(Book[] Books)
        {

            for (int i = 0; i < Books.Length; i++)
            {
                int count = i + 1;
                Console.WriteLine($"{count}. {Books[i].Title}, by {Books[i].Writer.DisplayName()}, {Books[i].Description}, totalPages is {Books[i].PagesCount}");
            }
        }

    }
}

