using System;
using System.Buffers;
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
        public Warehouse warehouse;
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

        void AddNewProduct(Product product)
        {

        }
        Product GiveProduct()
        {
            return null;
        }
        int SearchProduct(string phonenumber)
        {
            throw new NotImplementedException();
        }
        void ReturnProduct(Product product)
        {

        }
    }

    struct Date
    {
        public DateTime expDate;
        public DateTime prodDate;

        public Date(int days)
        {
            prodDate = DateTime.Today;
            expDate = prodDate.AddDays(days);
        }

    }

    enum ProductType
    {
        Dairy,
        Fruit,
        Vegetable,
        Meat,
        Fish,
        Green
    }

    class Buyer
    {
        string _name;
        string _surname;
        string _email;
        string _phone;
        int _cash;
        Cart _cart;

         Receipt CheckOut()
        {
            throw new NotImplementedException();
        }

        Product ReturnProduct(string name)
        {
            throw new NotImplementedException();
        }
        void PutInCart(Product product)
        {

        }

    }

    class Product
    {
        int _id;
        string _name;
        ProductType _type;
        int _cost;
        Date _date;
        int _quantity;

        public int ID => _id;
        public string Name => _name;
        public ProductType Type => _type;
        public int Prise => _cost;
        public DateTime ProdDate => _date.prodDate;
        public DateTime ExpDate => _date.expDate;
        public int Quantity => _quantity;

        public Product(int id, string name, ProductType type, int cost, int quantity)
        {
            _id = id;
            _name = name;
            _type = type;
            _cost = cost;

            _date = type switch
            {
                ProductType.Dairy or ProductType.Fish or ProductType.Meat => new Date(3),
                ProductType.Fruit or ProductType.Green => new Date(10),
                ProductType.Vegetable => new Date(8),
                _ => new Date(1)
            };

            _quantity = quantity;
        }

        public void AddQuantity(int quantity)
        {
            this._quantity += quantity;
        }
        public void ReduceQuantity(int reduce)
        {
            this._quantity -= reduce;
        }

    class Cart
    {
        Product[] _products;

        // add
        void AddProduct(Product product)
        {

        }
        int SearchProduct(string name)
        {
            return -1;
        }
        // remove
        void RemoveProduct(string name)
        {

        }
        int CountTotalPrise()
        {
            return 0;
        }


    }

    class Receipt
    {
        string _ownerPhone;
        int _totalCartValue;

        public string Owner => _ownerPhone;
        public int Value => _totalCartValue;

        public Receipt(string phone, int value)
        {
            _ownerPhone = phone;
            _totalCartValue = value;
        }
    }
}