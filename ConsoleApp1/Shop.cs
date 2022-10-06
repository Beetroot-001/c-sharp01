using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Shop
    {
        private  List<IProduct> products = new List<IProduct>();
        private  List<IBuyer> buyers = new List<IBuyer>();
        private  List<IReceipt> receipts = new List<IReceipt>();

        /// <summary>
        /// Add new product to the shop
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(IProduct product)
        {
            products.Add(product);
        }
        /// <summary>
        /// Add quantity of goods to the existed product in the shop
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        public void AddProductQuantity(IProduct product, int quantity)
        {
            int index;
            
            if (ContainProduct(product, out index))
            {
                products[index].Quantity += quantity;
            }
        }

       /// <summary>
       /// Register new buyer to the shop
       /// </summary>
       /// <param name="buyer"></param>
        public void RegisterNewBuyer(IBuyer buyer)
        {
            buyers.Add(buyer);
        }

        /// <summary>
        /// Add receipt to the receipt list 
        /// </summary>
        /// <param name="receipt"></param>
        private void AddReceipt(IReceipt receipt)
        {
            receipts.Add(receipt);
        }
     
        /// <summary>
        /// Sell a product to the custmer and add a receipt of the purchase to the shop and to customer
        /// </summary>
        /// <param name="buyer"></param>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        public void SellProduct(IBuyer buyer, IProduct product, int quantity)
        {
            int index;
            if (ContainProduct(product, out index) && products[index].Quantity>= quantity)
            {
                products[index].Quantity -= quantity;
                AddReceipt(new Receipt(product, buyer, quantity));
                buyer.GetReceipt(new Receipt(product, buyer, quantity));
                return;
            }
            Console.WriteLine("The product is not available");
        }

        /// <summary>
        /// Check if the shop contains product
        /// </summary>
        /// <param name="product"></param>
        /// <param name="index"></param>
        /// <returns>Return true if product exists and its index in the product list, false if the product doesn't exist and 0</returns>
        private bool ContainProduct(IProduct product, out int index)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i] == product)
                {
                    index = i;
                    return true;
                }
            }
            index = 0;
            return false;
        }

        /// <summary>
        /// Show all products available in the shop and their quantity
        /// </summary>
        public void ShowProductsList()
        {
            Console.WriteLine("The List of Products");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"#{i+1} Product name: {products[i].Name} quantity: {products[i].Quantity}");
            }
        }

        /// <summary>
        /// Show all buyers registered in the shop
        /// </summary>
        public void ShowBuyersList()
        {
            Console.WriteLine("The List of Buyers");
            for (int i = 0; i < buyers.Count; i++)
            {
                Console.WriteLine($"#{i + 1} Buyer name: {buyers[i].Name} Personal Info: {buyers[i].PersonalInfo}");
            }
        }

        /// <summary>
        /// Show info about all receipts collected in the shop
        /// </summary>
        public void ShowReceiptList()
        {
            Console.WriteLine("The List of Receipts");
            foreach (var item in receipts)
            {
                Console.WriteLine($"Buyer Name: {item.Buyer.Name}");
                Console.WriteLine($"Product: {item.SoldProduct.Name}");
                Console.WriteLine($"Qantity: {item.Quantity}");
                Console.WriteLine("- - - - - - - - - - - - - -");
            }
        }

        private void ShopNavigation()
        {
            Console.WriteLine("0.Leave the shop");
            Console.WriteLine("1.Register a new type of product to the shop");
            Console.WriteLine("2.Add quantity to the existed product in the shop");
            Console.WriteLine("3.Register a new buyer");
            Console.WriteLine("4.Sell product");
            Console.WriteLine("5.Show the list of products");
            Console.WriteLine("6.Show the list of buyers");
            Console.WriteLine("7.Show list of recipts");
        }

        public void ShopMenu()
        {
            int option = 1;

            while (option!=0)
            {
                ShopNavigation();
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Provide the new name of the product");                       
                        string name = Console.ReadLine();

                        Console.WriteLine("Provide description of new product");
                        string description = Console.ReadLine();

                        Console.WriteLine("Provide price of new product");
                        int price;                            
                        int.TryParse(Console.ReadLine(), out price);                       
                        AddProduct(new Product(name, description, 0, price));

                        Console.Clear();
                        break;

                    case 2:
                        ShowProductsList();
                        Console.WriteLine("Choose the product to increase quantity");
                        int index = int.Parse(Console.ReadLine());
                        var product = products[index - 1];

                        Console.WriteLine("Indicate the quantity of products you want to add");
                        int quantity = int.Parse(Console.ReadLine());
                        AddProductQuantity(product, quantity);
                       
                        Console.Clear();
                        break;

                    case 3:
                        Console.WriteLine("Provide new customer's name");
                        string buyerName = Console.ReadLine();

                        Console.WriteLine("Provide info about new customer");
                        string info = Console.ReadLine();
                        RegisterNewBuyer(new Buyer(buyerName, info));

                        Console.Clear();
                        break;

                    case 4:
                        ShowBuyersList();
                        Console.WriteLine("Choose the buyer to sell product");
                        int buyerIndex = int.Parse(Console.ReadLine());                   

                        ShowProductsList();
                        Console.WriteLine("Choose the product to sell");
                        int productIndex = int.Parse(Console.ReadLine());

                        Console.WriteLine("How many items to sell?");
                        int productQuantity = int.Parse(Console.ReadLine());

                        SellProduct(buyers[buyerIndex - 1], products[productIndex - 1], productQuantity);

                        Console.Clear();
                        break;

                    case 5:
                        Console.Clear();
                        ShowProductsList();
                        Console.WriteLine("****************************");
                        break;

                    case 6:
                        Console.Clear();
                        ShowBuyersList();
                        Console.WriteLine("****************************");
                        break;

                    case 7:
                        Console.Clear();
                        ShowReceiptList();
                        Console.WriteLine("****************************");                       
                        break;

                    case 0:
                        break;
                }
            }
        }
    }
}
