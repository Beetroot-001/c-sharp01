namespace ConsoleApp1
{
    class Registration
    {
        Receipt[] _records;
        Buyer[] _registers;

        public Registration()
        {
            _records = new Receipt[1];
            _registers = new Buyer[1];
        }

        public void DisplayRecords()
        {
            for (int i = 0; i < _records.Length - 1; i++)
            {
                _records[i].DisplayReceipt();
                Console.WriteLine();
            }
        }

        public void DisplayRegisters()
        {
            for (int i = 0; i < _registers.Length - 1; i++)
            {
                _registers[i].DisplayBuyerInfo();
                Console.WriteLine();
            }
        }

        public void AddRecord(Receipt receipt)
        {   
            _records[^1] = receipt;
            Array.Resize(ref _records, _records.Length + 1);
        }

        public bool TryFindRecord(string phone, out int id)
        {
            for (int i = 0; i < _records.Length - 1; i++)
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
                for (int i = index; i < _records.Length - 2; i++)
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
            int id;
            if(!TryFindRecord(buyer.Phone, out id))
            {
                _registers[^1] = buyer;
                Array.Resize(ref _registers, _registers.Length + 1);
                return;
            }
            Console.WriteLine("Already in the base!");
        }
    }


}