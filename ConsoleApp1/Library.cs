using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    static class Library
    {
        public static List<Book> books = new List<Book>();
        private static List<LibraryCard> cards = new List<LibraryCard>();


       
        public static void ListofBooks()
        {
            foreach (var item in books)
            {
                int id = 1;
                Console.WriteLine(item.BookInfoShort());
                id++;
            }
        }


        public static void AddBook(params Book [] newbook)
        {
            for (int i = 0; i < newbook.Length; i++)
            {
                books.Add(newbook[i]);
            }
        }




    }
}
