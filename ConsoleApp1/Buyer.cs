using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Buyer
    {
        private string _name;
        private string _email;
        private string _phone;
        private List<Receipt> _history;

        public Buyer (string name, string email, string phone)
        {
            _name = name;
            _email = email;
            _phone = phone;
            _history = new List<Receipt>(); 
        }

        public string Name 
        { 
            get => _name;
            set => _name = value;   
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public string Phone
        {
            get => _phone;
            set => _phone = value;
        }

        public List<Receipt> History
        {
            get => _history;
        }

        public void AddReceipt(Receipt receipt)
        {
            _history.Add(receipt);
        }

        public void ClearHistory()
        {
            _history.Clear();
        }

        public override string ToString()
        {
            return $"Name: {Name}\nEmail: {Email}\nPhone: {Phone}";
        }
    }
}
