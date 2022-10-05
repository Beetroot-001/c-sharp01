using System;
using System.Net.Http.Headers;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{

		}
	}
    interface IShop
    {
        void RegisterNewProduct(Product product);
        void AddQuantity(int quantity, Product product);
        bool SellProduct(Receipt receipt);
        bool RegisterBuyer(Buyer buyer);

    }

    class InternetShop : IShop
    {
        public Registration[] registrations;
        public Warehouse;
        public void RegisterNewProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void AddQuantity(int quantity, Product product)
        {
            throw new NotImplementedException();
        }

        public bool SellProduct(Receipt receipt)
        {
            throw new NotImplementedException();
        }

        public bool RegisterBuyer(Buyer buyer)
        {
            throw new NotImplementedException();
        }


    }

    class Registration 
    {
        Receipt[] _records;
        Buyer[] _registers;

        public void AddRecord()
        {
            throw new NotImplementedException();
        }

        public Receipt GetRecords(string phone)
        {
            throw new NotImplementedException();
        }

        public Receipt DeleteRecords(string phone)
        {
            throw new NotImplementedException();
        }

        public void AddBuyer(Buyer buyer)
        {
            throw new NotImplementedException();
        }
    }

    class Warehouse
    {
        Product[] _available;
        Product[] _toOrder;

        void AddNewProduct()
        {

        }
        void GiveProduct()
        {

        }
        int SearchProduct(string phonenumber)
        {
            throw new NotImplementedException();
        }
        void ReturnProduct()
        {

        }
    }

    class Buyer
    {

    }

    class Product
    {

    }

    class Receipt
    {

    }
}