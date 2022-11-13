namespace ConsoleApp1
{
    internal class LoginForm
    {
        private Customer[] customers;
        private int regCount = 0;
        public bool logOn = false;

        public void Register(Customer customer)
        {
            customer.isRegistered = true;
            regCount++;
            Array.Resize(ref customers, regCount);
            customer.Name = customer.Name;
            customer.Email = customer.Email;
            customers[regCount - 1] = customer;
        }

        public void Login(Customer customer)
        {
            logOn = false;
            if (customer.isRegistered == true)
            {
                Console.WriteLine("Enter password: ");
                string tempPas = Console.ReadLine();
                if (tempPas == null)
                {
                    throw new Exception("Enter correct password!");
                    Login(customer);
                }
                else
                {
                    foreach (Customer customer2 in customers)
                    {
                        if (customer.EnterPassword() == tempPas)
                        {
                            logOn = true;
                            Console.WriteLine("Login successful!");
                        }
                    }
                }
            }
            else
            {
                Register(customer);
            }
        }

        public bool CheckRegStatus(Customer customerCur)
        {
            foreach (Customer customer in customers)
            {
                if (customerCur == customer && customer.isRegistered == true)
                {
                    Console.WriteLine("Email is registered!");
                    return true;
                }
                else { Console.WriteLine("Customer is not registered"); }
            }
            return false;
        }
    }
}