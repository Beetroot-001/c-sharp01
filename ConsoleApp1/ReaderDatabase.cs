using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ReaderDatabase
    {
        private List<ReaderCard> _readers;

        public ReaderDatabase()
        {
            _readers = new List<ReaderCard>();
        }

        public int Capasity { get { return _readers.Count; } }
        public List<ReaderCard> Readers { get { return _readers; } }

        public void AddNewCard(ReaderCard card)
        {
            _readers.Add(card);
        }

        public int SearchRecord(Reader owner)
        {
            foreach(ReaderCard readerCard in _readers)
            {
                if (readerCard.owner.Equals(owner))
                {
                    return _readers.IndexOf(readerCard);
                }
            }
            return -1;
        }

        public bool DeleteRecord(ReaderCard owner)
        {
            return _readers.Remove(owner);
        }
    }
}
