using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ConsoleInterface
    {
        private readonly Shop _shop;

        public ConsoleInterface()
        {
            _shop = new Shop();
        }

        public void StartInterface()
        { 
            while (true)
            {
                Console.WriteLine("Main menu:");
                Console.WriteLine("1. Show products");
                Console.WriteLine("2. Add new product");
                Console.WriteLine("3. Add product Quantity");
                Console.WriteLine("4. Show buyers");
                Console.WriteLine("5. Register new buyer");
                Console.WriteLine("6. Create new receipt");

                var read = Console.ReadKey();
                Console.SetCursorPosition(0, Console.GetCursorPosition().Top);

                switch (read.Key)
                {
                    case ConsoleKey.D1:
                        if (!ShowList(_shop.Products))
                            Console.WriteLine("Thare is no products");
                        break;
                    case ConsoleKey.D2:
                        AddProduct();
                        break;
                    case ConsoleKey.D3:
                        AddQuantity();
                        break;
                    case ConsoleKey.D4:
                        if (!ShowList(_shop.Buyers))
                            Console.WriteLine("Thar is no buyers");
                        break;
                    case ConsoleKey.D5:
                        RegisterBuyer();
                        break;
                    case ConsoleKey.D6:
                        CreateRecaipt();
                        break;
                    case ConsoleKey.D0:
                    default:
                        return;
                }
                Console.ReadKey();
                Console.Clear();
            }            
        }

        public static bool ShowList<T>(List<T> list)
        {
            if (list is null || list.Count == 0)
            {
                return false;
            }

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {list[i].ToString}");
            }
            return true;
        }

        private static int InputInt()
        {
            int num;

            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("invalid input");
            }
            return num - 1;
        }

        private static decimal InputDecimal()
        {
            decimal num;

            while (!decimal.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("invalid input");
            }
            return num - 1;
        }

        private static int InputInt(Func<int, bool> inputConditions)
        {
            int num;

            while (!int.TryParse(Console.ReadLine(), out num) && !inputConditions(num - 1))
            {
                Console.WriteLine("invalid input");
            }
            return num - 1;
        }

        private static int SelectInList<T>(List<T> list, string message = "Enter item number: ")
        {
            ShowList(list);

            Console.Write(message);

            return InputInt((index) => index >= 0 && index < list.Count);
        }

        private void AddProduct()
        { 
            Console.Write("Enter name: ");
            string name = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter price: ");
            decimal price = InputDecimal();

            Console.Write("Enter Quantity: ");
            int quantity = InputInt();

            _shop.AddProduct(new Product(name, price, quantity));
        }

        private void AddQuantity()
        {
            int num = SelectInList(_shop.Products, "Enter product number: ");

            Console.Write("Enter addition quantity: ");

            _shop.Products[num].Quantity += InputInt((input) => input >= 0);
        }

        private void RegisterBuyer()
        {
            Console.Write("Enter full name: ");
            string name = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter email: ");
            string email = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter phone: ");
            string phone = Console.ReadLine() ?? string.Empty;

            _shop.AddBuyer(new Buyer(name, email, phone));
        }

        private void CreateRecaipt()
        {
            int num = SelectInList(_shop.Buyers, "Enter buyer number: ");

            Receipt receipt = new(_shop.Buyers[num]);

            while (ReceiptMenu(receipt));
        }

        private bool ReceiptMenu(Receipt receipt)
        {
            Console.WriteLine("1. Show added products");
            Console.WriteLine("2. Add product");
            Console.WriteLine("3. Remove product");
            Console.WriteLine("4. Close receipt");
            Console.WriteLine("0. Cancel receipt");

            var read = Console.ReadKey();
            Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
            int num;

            switch (read.Key)
            {
                case ConsoleKey.D1:
                    if (!ShowList(receipt.Products))
                        Console.WriteLine("Thare is no products");
                    return true;
                case ConsoleKey.D2:
                    num = SelectInList(_shop.Products, "Enter product number: ");

                    receipt.AddProduct(_shop.Products[num]);
                    return true;
                case ConsoleKey.D3:
                    num = SelectInList(_shop.Products, "Enter product number: ");

                    receipt.RemoveProduct(num);
                    return true;
                case ConsoleKey.D4:
                    Console.WriteLine($"Receipt Clossed\n{receipt.ToString}");
                    receipt.Buyer.AddReceipt(receipt);
                    return false;
                case ConsoleKey.D0:
                default:
                    Console.WriteLine("receipt canceled");
                    return false;
            }
        }
    }
}