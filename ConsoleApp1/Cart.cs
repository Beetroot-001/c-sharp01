namespace ConsoleApp1
{
    class Cart
    {
        private Product[] _products;
        public int Size => _products.Length;

        public Cart()
        {
            _products = new Product[1];
        }
        public void DisplayProducts()
        {
            for (int i = 0; i < _products.Length - 1; i++)
            {
                _products[i].DisplayProduct();
            }
        }
        public void AddProduct(Product product)
        {
            _products[^1] = product;
            Array.Resize(ref _products, Size + 1);
        }
        public bool TrySearchProduct(string name, out int id)
        {
            for (int i = 0; i < Size - 1; i++)
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
                for (int i = index; i < Size - 2; i++)
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
            for (int i = 0; i < Size - 1; i++)
            {
                total += _products[i].Prise * _products[i].Quantity;
            }
            return total;
        }
        public void Clear()
        {
            _products = new Product[1];
        }
    }
}