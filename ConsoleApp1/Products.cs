namespace ConsoleApp1
{
    internal class Products
    {
        public int price;
        public int quantity;
        public Discount Discount { get; set; }
        string productName;
        int totalAvailable;

        public Products(int price, int quantity, string productName, int totalAvailable)
        {
            this.price = price;
            this.quantity = quantity;
            this.productName = productName; 
            this.totalAvailable = totalAvailable;   
        }

    }

    public enum Discount
    {
        InDiscount,
        ExcludedFromDiscount
    }
}
