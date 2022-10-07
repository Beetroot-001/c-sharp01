namespace ConsoleApp1
{
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

        public void DisplayReceipt()
        {
            Console.WriteLine("Buyer phonenumber: " + _ownerPhone);
            Console.WriteLine("Spendings per receipt: " + _totalCartValue);
            Console.WriteLine();
        }
    }
}