using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    internal struct Price
    {
        private decimal price;
        public Price(decimal price)
        {
            this.price = price;
        }

        public decimal PriceDigit { get{ return price; } set { price = value; } }
        public string PriceInfo => price.ToString("C", new CultureInfo("en-US"));
    }
}
