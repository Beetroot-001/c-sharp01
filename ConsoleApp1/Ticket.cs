using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Ticket
    {
        private string[] readers;
        public int Id = 1;
        
        public void AddReader(Reader reader)
        {
            Array.Resize(ref readers, Id + 1);
            readers[0] = "Id, Name, Age, Description";
            readers[Id] = $"{Id}" + ", " + $"{reader.name}" + ", " + $"{reader.age}" + ", " + $"{reader.description}";

            Id++;
        }

        public void DeleteReader(int Id)
        {
            string temp = readers[readers.Length - 1];
            readers[readers.Length - 1] = readers[Id];
            readers[Id] = temp;
            Array.Resize(ref readers, readers.Length - 1);
        }
        public void ReadList()
        {
            foreach (var reader in readers)
                Console.WriteLine(reader);
        }
        

    }
}
