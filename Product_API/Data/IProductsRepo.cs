namespace Product_API.Data
{
    public interface IProductsRepo 
    {
        Task <IEnumerable<Product>> GetAll();

        Task<Product> GetById(int id);

        Task<Product> Create(Product product);

        Task Delete(Product product);

        Task SaveChanges();
    }
}
