using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Receipts : IInfo
    {
        public int ID { get ; set ; }
        public float Prise { get; set; }
        public Shop NameShop { get; private set; }// ЯК ПРОКИНУТИ дефолтне імя магазину?

        private Buyer _buyer;
        private Seller _seller;
        private Goods[] _gooods;

        public Receipts(Buyer buyer, Seller seller, Goods[] goods )
        {
            this._buyer = buyer;
            this._seller = seller;  
            this._gooods = goods;
            this.ID = GetsID.GetID();
        }
        public string GetFullInfo()
        {
            Console.WriteLine($"Buyer: ");
            return "";
        }
    }
}
