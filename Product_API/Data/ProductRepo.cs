using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product_API.Context;

namespace Product_API.Data
{  
    public class ProductRepo : IProductsRepo
    {
        private readonly ProductsContext productsContext;

        public ProductRepo(ProductsContext productsContext)
        {
            this.productsContext = productsContext;
        }

        public async Task<Product> Create(Product product)
        {
            productsContext.Add(product);// додамо просто продукт 

            productsContext.Products.Add(product);// яка різниця між першим і другим?

            await productsContext.SaveChangesAsync(); 

            return product; // продукт просетапиться і віддасть продукт з ID
        }

        
        public async Task Delete(Product product)
        {
            productsContext.Products.Remove(product);

            await productsContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await productsContext.Products.AsNoTracking().ToListAsync();

            return products;
        }

        public async Task<Product> GetById(int id)
        {
            var product = await productsContext.Products.FirstOrDefaultAsync(x => x.ProductId == id);

            return product;
        }

        public  Task SaveChanges()
        {
            return  productsContext.SaveChangesAsync();
        }
    }
}
