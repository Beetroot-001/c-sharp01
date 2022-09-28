using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Reader
    {
        public string ReaderFirstName { get; set; }
        public string ReaderLastName { get; set; }  
        public ReaderCardInfo ReaderCardInfo { get; set; }
        public DateTime DOB { get; set; }

        public Reader(string readerFirstName, string readerLastName, ReaderCardInfo readerCardInfo, DateTime dOB)
        {
            ReaderFirstName = readerFirstName;
            ReaderLastName = readerLastName;
            ReaderCardInfo = readerCardInfo;
            DOB = dOB;
        }
    }
}
