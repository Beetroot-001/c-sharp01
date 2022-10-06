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

        }
    }
    interface IShop
    {
        void RegisterNewProduct();
        void AddQuantity(string product, int quantity);
        bool SellProduct(Receipt receipt);
        void RegisterBuyer(Buyer buyer);

    }

    class InternetShop : IShop
    {
        public Registration registration;
        public Warehouse warehouse;
        public void RegisterNewProduct()
        {
            Console.WriteLine("Enter product name: ");
            string? name = Console.ReadLine();
            warehouse.AddProduct(name, 1);
        }

        public void AddQuantity(string product, int quantity)
        {
            warehouse.AddProduct(product, quantity);
        }

        public bool SellProduct(Receipt receipt)
        {
            throw new NotImplementedException();
        }

        public void RegisterBuyer(Buyer buyer)
        {
            registration.AddBuyer(buyer);
        }
    }

    class Registration
    {
        Receipt[] _records;
        Buyer[] _registers;

        public void AddRecord(Receipt receipt)
        {
            _records[^1] = receipt;
            Array.Resize(ref _records, _records.Length + 1);
        }

        public bool TryFindRecord(string phone, out int id)
        {
            for (int i = 0; i < _records.Length; i++)
            {
                if (_records[i].Owner == phone)
                {
                    id = i;
                    return true;
                }
            }
            id = -1;
            return false;
            
        }

        public bool TryDeleteRecord(string phone, out Receipt? receipt)
        {
            int index;
            if(TryFindRecord(phone, out index))
            {
                receipt = _records[index];
                for (int i = index; i < _records.Length - 1; i++)
                {
                    _records[i] = _records[i + 1];
                }
                return true;
            }
            receipt = null;
            return false;
        }

        public void AddBuyer(Buyer buyer)
        {
            _registers[^1] = buyer;
            Array.Resize(ref _registers, _registers.Length + 1);
        }
    }

    class Warehouse
    {
        Product[] _available;
        Product[] _toOrder;

        public Warehouse()
        {
            _available = new Product[1];
            _toOrder = new Product[1];
        }
        public bool TrySearchProduct(string name, out int id)
        {
            for (int i = 0; i < _available.Length; i++)
            {
                if (_available[i].Name == name)
                {
                    id = i;
                    return true;
                }
            }
            id = -1;
            return false;
            
        }

        public Product AddNewProduct(string name, int quantity)
        {
            Console.WriteLine("Enter type: ");
            // choose tyep
            ProductType type = ProductType.Dairy;
            Console.WriteLine("Enter id: ");
            int id = 1;
            Console.WriteLine("Enter cost per unit: ");
            int cost = 5;
            return new Product(id, name, type, cost, quantity);
        }
        public void AddProduct(string name, int quantity)
        {
            int index = 0;
            if(TrySearchProduct(name, out index))
            {
                _available[index].AddQuantity(quantity);
                return;
            }
            _available[^1] = AddNewProduct(name, quantity);
            Array.Resize(ref _available, _available.Length + 1);
        }
        public bool TryGiveProduct(string name, out Product? product, int quantity)
        {
            int index;
            if (TrySearchProduct(name, out index))
            {
                if (_available[index].Quantity >= quantity)
                {
                    Console.WriteLine("Giving a product :)");
                    product = new Product(_available[index], quantity);
                    _available[index].ReduceQuantity(quantity);
                }
                else if (_available[index].Quantity >= 0)
                {
                    Console.WriteLine("Giving smaller amount :\\");
                    product = new Product(_available[index], _available[index].Quantity);
                    _available[index].ReduceQuantity(_available[index].Quantity);
                }
            }
            Console.WriteLine("Giving 0 amount, no product to give :(");
            product = null;
            return false;
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

        public Date(DateTime exp, DateTime prod)
        {
            prodDate = exp;
            expDate = prod;
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

        public string Name => _name;
        public string Surname => _surname;
        public string Email => _email;
        public string Phone => _phone;
        public int Cash => _cash;

        public void PutInCart(Product product)
        {
            _cart.AddProduct(product);
        }
        public bool TryCheckOut(out Receipt? receipt)
        {
            if(_cart.Size == 0)
            {
                receipt = null;
                return false;
            }
            receipt = new Receipt(this._phone, _cart.Size);
            return true;
        }
        public bool ReturnProduct(string name, out Product? product)
        {
            return _cart.RemoveProduct(name, out product) ? true : false;
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

        public Product(Product prototype, int quantity)
        {
            _id = prototype.ID;
            _name = prototype.Name;
            _type = prototype.Type;
            _cost = prototype.Prise;
            _date = new Date(prototype.ExpDate, prototype.ProdDate);
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
    }
    class Cart
    {
        Product[] _products;

        public int Size => _products.Length;

        public void AddProduct(Product product)
        {
            _products[^1] = product;
            Array.Resize(ref _products, Size + 1);
        }
        public bool TrySearchProduct(string name, out int id)
        {
            for (int i = 0; i < Size; i++)
            {
                if (_products[i].Name == name)
                {
                    id = i;
                    return true;
                }
            }
            id = -1;
            return false;
        }
        public bool RemoveProduct(string name, out Product? product)
        {
            int index;
            if(TrySearchProduct(name, out index))
            {
                product = _products[index];
                for (int i = index; i < Size - 1; i++)
                {
                    _products[i] = _products[i + 1];
                }
                Array.Resize(ref _products, Size - 1);
                return true;
            }
            else
            {
                product = null;
                Console.WriteLine("There isn't such product in a cart");
                return false;
            }
        }
        public int CountTotalPrise()
        {
            int total = 0;
            for (int i = 0; i < Size; i++)
            {
                total += _products[i].Prise * _products[i].Quantity;
            }
            return total;
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