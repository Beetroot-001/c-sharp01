using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Discount:IInfo
    {
        public int SizeOfDiscount { get; set; }
        public Goods GoodsOfDiscount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Quantity { get; set; }
        public int ID { get; set; }
        public string PromotionСonditions { get; set; }

        public Discount(int sizeOfDiscount, Goods goodsOfDiscount, DateTime startDate, DateTime endDate, int quantity, string promotionСonditions)
        {
            SizeOfDiscount = sizeOfDiscount;
            GoodsOfDiscount = goodsOfDiscount;
            StartDate = startDate;
            EndDate = endDate;
            Quantity = quantity;
            ID = GetsID.GetID();
            PromotionСonditions = promotionСonditions;
        }

        public void GetFullInfo()
        {
            throw new NotImplementedException();
        }

        public void GetData()
        {

        }
    }
}
