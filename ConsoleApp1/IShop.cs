namespace ConsoleApp1
{
    internal interface IShop
    {
        public void RegisterNewProduct(Products product);
        public void AddQuantityToExistent(Buyers buyerData, Products product); 
        public void SellProduct(Products product);
        public void RegisterBuyer(Buyers buyerData); 
    }
}
