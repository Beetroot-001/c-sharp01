namespace Product_API.Exceptoins
{
    public class ProductIsnotValidExceptoin : Exception
    {
        public ProductIsnotValidExceptoin(string? message) : base(message)
        {
        }
    }
}
