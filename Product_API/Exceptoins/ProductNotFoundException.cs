namespace Product_API.Exceptoins
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string? message) : base(message)
        {
        }
    }
}
