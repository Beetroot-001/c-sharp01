namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Ticket ticket = new Ticket();
            Library library = new Library();

            Reader john = new Reader(18, "John", "Avid book enjoyer");

            Reader lenny = new Reader(26, "Leonard", "Just chillin");

            Reader richard = new Reader(43, "Richard", "Builder");

            Writer dickens = new Writer("Charles Dickens", "Charles John Huffam Dickens was an English writer and social critic. He created some of the world's best-known fictional characters");
            Writer kulish = new Writer("Mykola Kulish" ,"a Ukrainian prose writer, playwright, pedagogue, veteran of World War I, and Red Army veteran. He is considered to be one of the lead figures of Executed Renaissance.");
            
            Book oliver = dickens.WriteBook(300, "Oliver Twist", dickens.Name);
            Book myna = kulish.WriteBook(450, "Myna Mazailo", kulish.Name);

            library.AddBook(oliver);
            library.AddBook(myna);            
            library.ShowLibrary();            

            ticket.AddReader(john);
            ticket.AddReader(lenny);
            ticket.AddReader(richard);
            
            john.GetBook(oliver, ticket);
            john.GetBook(myna, ticket);
            lenny.GetBook(oliver, ticket);
            richard.GetBook(oliver, ticket);
            Console.WriteLine(oliver.ReadTimes);
            Console.WriteLine(myna.ReadTimes);
            ticket.ReadList();

            ticket.DeleteReader(2);
            ticket.ReadList();

            library.SearchBook();
        }
    }
}