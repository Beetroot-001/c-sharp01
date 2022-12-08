using Microsoft.AspNetCore.JsonPatch;
using Product_API.Data;

namespace Product_API.Servises
{
    public interface IProductServices
    {
        Task<IEnumerable<Product>> GetAll();

        Task<Product> GetById(int id);

        Task<Product> Create(Product product);

        Task Delete(int id);

        Task<Product> Update(int id, JsonPatchDocument<Product> jsonPatch);
    }
}
