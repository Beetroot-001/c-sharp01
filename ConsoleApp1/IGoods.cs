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

        public int Weight { get; set; }
        public int UahValue { get; set; }
        public int Quantity { get; set; }

        public bool isAvalableNow
        {
            get { return isAvalableNow; }
            set
            {
                if (Quantity == 0)
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
            return UahValue * Value.currencyRate;
        }
    }
}