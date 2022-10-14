using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Shop
    {
        private Shop myShop;
        public Goods[] AllGoods { get; set; }
        public Seller[] AllSeller { get; set; }
        public Buyer[] AllBuyer { get; set; }
        public Receipts[] ArchiveReceipts { get; set; }
        public Discount[] AllDiscount { get; set; }

        public Shop()
        {
            myShop = myShop ?? new Shop();
        }

        public void AddGoods()
        {

        }
        public void AddSeller()
        {

        }
        public void AddBuyer()
        {

        }
        public void AddReceipts()
        {

        }
        public void DelGoods()
        {

        }
        public void DelSeller()
        {

        }
        public void DelBuyer()
        {

        }
        public void DelReceipts()
        {

        }
        public void GetInfo()
        {

        }
        public void Search()
        {

        }
        public void Sort()
        {

        }
        public void Compare()
        {

        }
        public void DisplayApp()
        {


        }
        public void SendReceipts(Buyer buyer)
        {
            Console.WriteLine($"Send Receipts in E-mail {buyer.Email}");
            Console.WriteLine($"text ");
        }
    }
}
