namespace ConsoleApp1
{
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

        public Buyer(string name, string surname, string email, string phone, int cash)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _phone = phone;
            _cash = cash;

            _cart = new Cart();
        }

        public void PutInCart(Product product)
        {
            _cart.AddProduct(product);
        }
        public bool TryCheckOut(out Receipt? receipt)
        {
            if(_cart.Size == 0 || _cash < _cart.CountTotalPrise())
            {
                Console.WriteLine("Unsuccessfull checkout! Check emptiness of your cart or wallet!");
                receipt = null;
                return false;
            } 
            _cash -= _cart.CountTotalPrise();
            receipt = new Receipt(this._phone, _cart.CountTotalPrise());
            _cart.Clear();
            Console.WriteLine("Checkout successfull");
            return true;
        }
        public bool ReturnProduct(string name, out Product? product)
        {
            return _cart.RemoveProduct(name, out product) ? true : false;
        }
        public void DisplayBuyerInfo()
        {
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("Surname: " + _surname);
            Console.WriteLine("Email: " + _email);
            Console.WriteLine("Phone: " + _phone);
            Console.WriteLine("Cash: " + _cash);
            _cart.DisplayProducts();
            Console.WriteLine();
            //display cart
        }
    }
}