using System;
using System.Buffers;
using System.Net.Http.Headers;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tysytsky shop!");
            InternetShop internetShop = new InternetShop();
            Buyer testBuyer = new Buyer("John", "", "", "0962345678", 1000);
            internetShop.warehouse.AddProduct("test", 100);
            internetShop.AddQuantity("test", 10);
            internetShop.warehouse.DisplayAvailable();
            internetShop.SellProduct(testBuyer);
            internetShop.warehouse.DisplayAvailable();
            internetShop.registration.DisplayRecords();
            testBuyer.DisplayBuyerInfo();
        }
    }
    interface IShop
    {
        void RegisterNewProduct();
        void AddQuantity(string product, int quantity);
        bool SellProduct(Buyer buyer);
        void RegisterBuyer(Buyer buyer);

    }

    class InternetShop : IShop
    {
        public Registration registration;
        public Warehouse warehouse;

        public InternetShop()
        {
            registration = new Registration();
            warehouse = new Warehouse();
        }
        public void RegisterNewProduct()
        {
            Console.WriteLine("Adding a new product!");
            Console.WriteLine("Enter product name: ");
            string? name = Console.ReadLine();
            AddQuantity(name, 1);
        }

        public void AddQuantity(string product, int quantity)
        {   
            try
            {
                warehouse.AddProduct(product, quantity);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool CheckContinue()
        {   
            return Console.ReadKey().Key == ConsoleKey.Y ? true : false;
        }

        public bool CheckOutBuyer(Buyer buyer)
        {
            Console.WriteLine("Check out? (y/n)");
            if (CheckContinue())
            {
                Receipt receipt;
                if (buyer.TryCheckOut(out receipt))
                {
                    Console.WriteLine("Successfull checkout!");
                    registration.AddRecord(receipt);
                    Console.WriteLine("Do you want to register? (y/n)");
                    if (CheckContinue())
                    {
                        RegisterBuyer(buyer);
                    }
                    Console.WriteLine("Thanks, see you next time!");
                    return true;
                }
            }
            return false;
        }

        public bool SellProduct(Buyer buyer)
        {
            Product product;
            Console.WriteLine("Enter product name: ");
            string name = Console.ReadLine();
            int quantity;
            if (!MyParse.IntParse(out quantity, "quantity"))
            {
                Console.WriteLine("Error: Input invalid. Try again? (y/n)");
                return false;
            }
            if (warehouse.TryGiveProduct(name, out product, quantity))
            {
                if (product.ExpDate < DateTime.Today)
                {
                    Console.WriteLine("Product is expired! Maybe someting else? (y/n)");
                    if (CheckContinue())
                    {
                        SellProduct(buyer);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Nothing more okay...");
                        bool success = CheckOutBuyer(buyer);
                    }
                }
                buyer.PutInCart(product);
                Console.WriteLine("Put successfully. Maybe someting else? (y/n)");
                if (CheckContinue())
                {
                    SellProduct(buyer);
                    return true;
                }
                else
                {
                    Console.WriteLine("Nothing more okay...");
                    bool success = CheckOutBuyer(buyer);
                }
            }
            
            return false;

        }

        public void RegisterBuyer(Buyer buyer)
        {
            registration.AddBuyer(buyer);
        }
    }


}