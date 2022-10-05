namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {         
            
            Library library = new Library();
            Reader john = new Reader(18, "John", "Avid book enjoyer");
            Reader lenny = new Reader(26, "Leonard", "Just chillin");
            Reader richard = new Reader(43, "Richard", "Builder");
            Writer dickens = new Writer("Charles Dickens", "Charles John Huffam Dickens was an English writer and social critic. He created some of the world's best-known fictional characters");
            Writer kulish = new Writer("Mykola Kulish" ,"a Ukrainian prose writer, playwright, pedagogue, veteran of World War I, and Red Army veteran. He is considered to be one of the lead figures of Executed Renaissance.");
            Writer sheva = new Writer("Taras Grygorovych", "Simply legend");
            Book oliver = dickens.WriteBook(300, "Oliver Twist", dickens.Name);
            Book myna = kulish.WriteBook(450, "Myna Mazailo", kulish.Name);
            Book kobzar = sheva.WriteBook(500, "kobzar", sheva.Name);
            
            library.AddBook(oliver);
            library.AddBook(myna);
            library.AddBook(kobzar);
            library.ShowLibrary();            
            library.DeleteBook(oliver);
            Console.WriteLine("Deleted Oliver Twist");
            library.ShowLibrary();
            Console.WriteLine();
            library.AddTicket(john);            
            library.AddTicket(lenny);            
            library.AddTicket(richard);
            library.ViewTickets();
            Console.WriteLine();
            library.DeleteTicket(john);
            Console.WriteLine("Deleted John");
            library.ViewTickets();
            Console.WriteLine();
            Console.WriteLine("Lenny now will take Myna Mazailo from library");
            library.GetBook(myna, library.GetTicketByReader(lenny));
            Console.WriteLine("Richard is jealous and now will also try to take Myna Mazailo from library");
            library.GetBook(myna, library.GetTicketByReader(richard));
            Console.WriteLine("Now Lenny has a book on his records");
            library.LookHistory(lenny);
            Console.WriteLine("And Richard remains jealous because");
            library.LookHistory(richard);                    
            
           
            
        }
    }
}