namespace ConsoleApp1
{
    internal class InternetShop : IShop
    {
        public Products Products { get; set; }
        public Receipts Receipts { get; set; }
        public Buyers Buyers { get; set; }

        public void AddQuantityToExistent(Buyers buyerData, Products product)
        {
            
        }

        public void RegisterBuyer(Buyers buyerData)
        {
            
        }

        public void RegisterNewProduct(Products product)
        {
           
        }

        public void SellProduct(Products product)
        {
            
        }
    }
}
