namespace Product_API.Data
{
    public interface IProductsRepo // Навіщо нам цей інтерфейс? загальний для всіх prodactrepo, але може в різних класах змінюватися реалізація??
    {
        Task <IEnumerable<Product>> GetAll();

        Task<Product> GetById(int id);

        Task<Product> Create(Product product);

        Task Delete(Product product);

        Task SaveChanges();
    }
}
