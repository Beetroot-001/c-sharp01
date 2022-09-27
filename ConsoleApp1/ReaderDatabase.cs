using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ReaderDatabase
    {
        private ReaderCard[] _readers;

        public ReaderDatabase()
        {
            _readers = new ReaderCard[1];
        }

        public int Capasity { get { return _readers.Length; } }
        public ReaderCard[] Readers { get { return _readers; } }

        public void DisplayRecords()
        {
            for (int i = 0; i < Capasity - 1; i++)
            {
                Console.WriteLine($"Record #{i}: ");
                _readers[i].owner.DisplayReaderInfo();
                _readers[i].DisplayBooks();
            }
        }
        public void AddNewCard(Reader owner)
        {
            ReaderCard newCard = new ReaderCard(owner, DateTime.Today.AddYears(1), 10);
            _readers[^1] = newCard;
            Array.Resize(ref _readers, _readers.Length + 1);
        }

        public int SearchRecord(Reader owner)
        {
            for (int i = 0; i < Capasity; i++)
            {
                if (_readers[i].owner.Equals(owner))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool DeleteRecord(Reader owner)
        {
            int index = SearchRecord(owner);
            
            if (index == -1)
            {
                return false;
            }
            else if (Capasity == 1)
            {
                _readers = new ReaderCard[1];
                return true;
            }
            ReaderCard[] newArray = new ReaderCard[Capasity - 1];
            for (int i = 0, j = 0; i < Capasity; i++, j++)
            {
                if(i == index)
                {
                    i++;
                }
                newArray[j] = _readers[i];
            }
            _readers = newArray;
            return true;
        }
    }
}
