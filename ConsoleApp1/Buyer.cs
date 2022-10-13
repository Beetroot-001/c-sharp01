using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Buyer : IBuyer
    {
        private string personalInfo;
        private string name;
        private List<IReceipt> receipts = new List<IReceipt>();
        public Buyer(string name, string personalInfo)
        {
            this.name = name;
            this.personalInfo = personalInfo;
        }
        public string PersonalInfo { get { return personalInfo; } }

        public string Name {get { return name; } }

        /// <summary>
        /// Get receipt after purchase and store it in the list of receipts 
        /// </summary>
        /// <param name="receipt"></param>
        public void GetReceipt(IReceipt receipt)
        {
            receipts.Add(receipt);
        }

        /// <summary>
        /// Show the list of all bought products 
        /// </summary>
        public void ShowBoughtProducts()
        {
            foreach (var item in receipts)
            {
                Console.WriteLine(item.SoldProduct.Name);
                Console.WriteLine(item.Quantity);
            }
        }
    }
}
