using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal interface IGoods
    {
        public string Name { get; set; }
        public struct Value
        {
            public static decimal currencyRate = 0.025574950m;
            public Value()
            {
            }
        }

        public int weight { get; set; }
        public int uahValue { get; set; }
        public int quantity { get; set; }
        public bool isAvalableNow
        {
            get { return isAvalableNow; }
            set
            {
                if (quantity == 0)
                {
                    isAvalableNow = false;
                }
            }
        }

        public decimal GetUSDVal(decimal uahValue)
        {
            return uahValue * Value.currencyRate;
        }

        public decimal GetUSDVal()
        {
            return uahValue * Value.currencyRate;
        }
    }
}
