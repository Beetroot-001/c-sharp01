namespace ConsoleApp1
{
    internal class Receipt
    {
        public Receipt(Basket bin)
        {
            bool empty = bin.NumOfGoods != 0 ? true : false;
            if (empty)
            {
                bin.customer.Buy(bin.TotalCost);
                Console.WriteLine("Purchase done!" + "\nRemaining balance: ");
                bin.customer.GetBalance();
            }
        }
    }
}