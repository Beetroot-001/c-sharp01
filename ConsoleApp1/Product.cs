namespace ConsoleApp1
{
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

    class Product
    {
        private int _id;
        private string _name;
        private ProductType _type;
        private int _cost;
        private Date _date;
        private int _quantity;

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
        public void DisplayProduct()
        {
            Console.WriteLine("ID: " + _id);
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("Type: " + _type);
            Console.WriteLine("Prise: " + _cost);
            Console.WriteLine("Quantity: " + _quantity);
            Console.WriteLine("Expiration date: " + _date.expDate);
            Console.WriteLine("Production date: " + _date.prodDate);
            Console.WriteLine();
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
}