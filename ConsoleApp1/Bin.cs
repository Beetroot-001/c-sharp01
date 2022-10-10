using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Bin
    {
        IGoods[] goods;
        public Customer customer;
        public int NumOfGoods = 0;
        public int TotalCost;
        public Bin(Customer customer, LoginForm login)
        {
            CheckIfLogon(customer, login);
        }
        public void CheckIfLogon(Customer customer, LoginForm login)
        {
            if (login.logOn == true)
            {
                this.customer = customer;
            }
            else { Console.WriteLine("Login first!"); login.Login(customer); CheckIfLogon(customer, login); }
        }
        public void AddGoods(IGoods goods1, int quantity)
        {
            do
            {
                if (goods1.quantity < quantity)
                {
                    Console.WriteLine("Position is unavailable!");
                    quantity = goods1.quantity;
                }
            }
            while (goods1.quantity > quantity);
            {
                for (int i = 0; i < quantity; i++)
                {
                    NumOfGoods++;
                    Array.Resize(ref goods, NumOfGoods);
                    goods[NumOfGoods - 1] = goods1;
                    goods1.quantity--;
                    TotalCost += goods1.uahValue;
                    Console.WriteLine("Position has been added to the bin!");
                }
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
            TotalCost -= goods1.uahValue * quantity;
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
