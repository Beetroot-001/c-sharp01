using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class InternetShop : Shop
    {
        public InternetShop(string name) : base(name) { }

        public override void AddBuyer()
        {
            throw new NotImplementedException();
        }

        public override Buyer GetBuyer(string phone)
        {
            throw new NotImplementedException();
        }

        public void ShowAllProducts()
        {
            for (int i = 0; i < Products.Count; i++)
            {
                Console.WriteLine($"{i}.{Products[i].Title}");
            }
        }
        public void AddQuantity()
        {
            string key;
            Product product;
            do
            {
                Console.WriteLine("Input product id or x to exit.");
                key = Console.ReadLine();
                if (new[] { "x", "х" }.Contains(key))
                {
                    break;
                }
                if (string.IsNullOrEmpty(key) || !int.TryParse(key, out int id) || id > Products.Count)
                {
                    Console.WriteLine("incorect Input or incorect id");
                    continue;
                }
                product = Products[id];
                do
                {
                    Console.WriteLine("Input new quantity. Or x to exit");
                    key = Console.ReadLine();
                    if (new[] { "x", "х" }.Contains(key))
                    {
                        break;
                    }
                    if (string.IsNullOrEmpty(key) || !int.TryParse(key, out int quantity))
                    {
                        Console.WriteLine("Incorect Input or incorect id");
                        continue;
                    }
                    product.NewQuantity(quantity);
                    break;
                } while (true);
                break;
            } while (true);
            
            
        }

        public void SellProduct()
        {
            string key;
            do
            {
                Console.WriteLine("Input product id or x to exit.");
                key = Console.ReadLine();
                if (new[] { "x", "х" }.Contains(key))
                {
                    break;
                }
                if (string.IsNullOrEmpty(key) || !int.TryParse(key, out int id) || id > Products.Count)
                {
                    Console.WriteLine("incorect Input or incorect id");
                    continue;
                }
                if(Products[id].Quantity == 0)
                {
                    Console.WriteLine("Sorry but you cant sell that product coz quantity is 0");
                    continue;
                }
                Products[id].ReduceQuantity();
            } while (true);

        }

        public override void AddProduct()
        {
            var product = Product.CreateNewProduct(Products.Count);
            Products.Add(product);
        }

        public override Product GetProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public override void AddReceipt(Receipt receipt)
        {
            throw new NotImplementedException();
        }
    }
}
