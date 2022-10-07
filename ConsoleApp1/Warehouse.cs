namespace ConsoleApp1
{
    class Warehouse
    {
        Product[] _available;
        Product[] _toOrder;

        public Warehouse()
        {
            _available = new Product[1];
            _toOrder = new Product[1];
        }

        public void DisplayAvailable()
        {
            for (int i = 0; i < _available.Length - 1; i++)
            {
                _available[i].DisplayProduct();
                Console.WriteLine();
            }
        }
        public bool TrySearchProduct(string name, out int id)
        {
            for (int i = 0; i < _available.Length - 1; i++)
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
        
        public Product? AddNewProduct(string name, int quantity)
        {
            Console.WriteLine("Enter type: ");
            
            ProductType type;
            int itype;
            Console.WriteLine("Variations: ");
            Console.WriteLine("1. Dairy");
            Console.WriteLine("2. Green");
            Console.WriteLine("3. Meat");
            Console.WriteLine("4. Fish");
            Console.WriteLine("5. Vegetable");
            Console.WriteLine("6. Fruit");
            if(MyParse.IntParse(out itype))
            {
                type = itype switch
                {
                    1 => ProductType.Dairy,
                    2 => ProductType.Green,
                    3 => ProductType.Meat,
                    4 => ProductType.Fish,
                    5 => ProductType.Vegetable,
                    6 => ProductType.Fruit,
                    _ => ProductType.Dairy
                };
            }
            else
            {
                type = ProductType.Dairy;
            }
            int id;
            int cost;
            if(MyParse.IntParse(out id, "id") && MyParse.IntParse(out cost, "cost"))
            {
                return new Product(id, name, type, cost, quantity);
            }
            return null;
        }
        public void AddProduct(string name, int quantity)
        {
            int index = 0;
            if(TrySearchProduct(name, out index))
            {
                _available[index].AddQuantity(quantity);
                return;
            }
            try
            {
                _available[^1] = AddNewProduct(name, quantity);
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException("Error occured: Adding a product was unsuccessfull... Error type: " + ex.GetType());
            }
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
                    return true;
                }
                else if (_available[index].Quantity >= 0)
                {
                    Console.WriteLine("Giving smaller amount :\\");
                    product = new Product(_available[index], _available[index].Quantity);
                    _available[index].ReduceQuantity(_available[index].Quantity);
                    return true;
                }
            }
            Console.WriteLine("Giving 0 amount, no product to give :(");
            product = null;
            return false;
        }

    }
}