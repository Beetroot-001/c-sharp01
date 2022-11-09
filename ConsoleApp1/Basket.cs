namespace ConsoleApp1
{
    internal class Basket
    {
        private IGoods[] goods;
        public Customer customer;
        public int NumOfGoods = 0;
        public int TotalCost;

        public Basket(Customer customer, LoginForm login)
        {
            CheckIfLogon(customer, login);
        }

        public void CheckIfLogon(Customer customer, LoginForm login)
        {
            if (login.logOn)
            {
                this.customer = customer;
            }
            else { Console.WriteLine("Login first!"); login.Login(customer); CheckIfLogon(customer, login); }
        }

        public void AddGoods(IGoods goods1, int quantity)
        {
            do
            {
                if (goods1.Quantity < quantity)
                {
                    Console.WriteLine("Position is unavailable!");
                    quantity = goods1.Quantity;
                }
            }
            while (goods1.Quantity > quantity);
            for (int i = 0; i < quantity; i++)
            {
                NumOfGoods++;
                Array.Resize(ref goods, NumOfGoods);
                goods[NumOfGoods - 1] = goods1;
                goods1.Quantity--;
                TotalCost += goods1.UahValue;
                Console.WriteLine("Position has been added to the bin!");
            }
        }

        public void RemoveGoods(IGoods goods1, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                NumOfGoods--;
                foreach (var good in goods)
                {
                    if (goods1 == good && good != goods[goods.Length - 1])
                    {
                        goods1 = goods[goods.Length - 1];
                        Array.Resize(ref goods, NumOfGoods);
                        break;
                    }
                    else if (goods1 == goods[goods.Length - 1])
                    {
                        Array.Resize(ref goods, NumOfGoods);
                    }
                }
            }
            TotalCost -= goods1.UahValue * quantity;
        }

        public void Checkout()
        {
            var dict = new Dictionary<IGoods, int>();
            foreach (var good in goods)
            {
                if (dict.ContainsKey(good))
                {
                    dict[good]++;
                }
                else
                {
                    dict[good] = 1;
                }
            }
            Console.WriteLine("Your bin:");
            if (goods.Length != 0)
            {
                foreach (var good in dict) { Console.WriteLine(good.Key.Name + " " + good.Value); }
                Console.WriteLine("Total cost: " + TotalCost);
                Console.WriteLine("Total cost in USD: " + goods[0].GetUSDVal(TotalCost));
            }
            else
            {
                Console.WriteLine("Your bin is empty!");
            }
        }
    }
}