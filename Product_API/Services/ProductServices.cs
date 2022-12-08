using Microsoft.AspNetCore.Mvc;
using Product_API.Data;
using Product_API.Servises;
using Microsoft.AspNetCore.JsonPatch;

namespace Product_API.Services
{
    public class ProductServices : IProductServices // не розумію навіщо цей клас
    {
        private readonly IProductsRepo productsRepo;// як воно розуміє який конкретно клас брати так як наслідників може бути багато?

        public ProductServices(IProductsRepo productsRepo)
        {
            this.productsRepo = productsRepo;
        }

        public Task<Product> Create(Product product)
        {
            if (string.IsNullOrEmpty(product.Taytle)||string.IsNullOrEmpty(product.Producer)||product.Priсe==null||product.Quantity==null)
            {
                throw new Exception("Product is not valid");
            }
            
            return productsRepo.Create(product);
        }

        public async Task Delete([FromRoute]int id)
        {
            var products = await productsRepo.GetById(id);// тут треба await якщо ми його реаліз в репо

            if (products==null)
            {
                throw new Exception("The product does not exist");
            }
            await productsRepo.Delete(products);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            if (productsRepo==null)
            {
                throw new Exception("No products have been added yet");
            }
            return await productsRepo.GetAll();
        }


        public async Task<Product> GetById([FromRoute] int id)
        {
            var products = await productsRepo.GetById(id);// тут треба await якщо ми його реаліз в репо

            if (products == null)
            {
                throw new Exception("The product does not exist");
            }

            return products;
        }

        public async Task<Product> Update([FromRoute] int id, JsonPatchDocument<Product> jsonPatch)
        {
            var products = await productsRepo.GetById(id);// тут треба await якщо ми його реаліз в репо

            if (products == null)
            {
                throw new Exception("The product does not exist");
            }

            jsonPatch.ApplyTo(products); // накатує зміни що прийшли на конкретний екземпляр

            await productsRepo.SaveChanges(); // зберігаю змінну

            return products;// куди винисти код що повторюється(пошук і перевірку)?? в окремий клас чи метод в цьому класі
        }
    }
}
