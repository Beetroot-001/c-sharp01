using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Product
    {   
        public int Id { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public float Price { get; private set; }
        public int Quantity { get; private set; }

        public Product(int sid)
        {
            Id = Id;
            Title = "";
            Price = 0.0f;
            Quantity = 1;
        }

        public static Product CreateNewProduct(int productsCount)
        {
            var product = new Product(productsCount);
            string key;
            do
            {
                Console.WriteLine("Input product name");
                key = Console.ReadLine();
                if (string.IsNullOrEmpty(key)) continue;
                product.Title = key;
            } while (string.IsNullOrEmpty(product.Title));

            do {
                Console.WriteLine("Input product description or x to skip.");
                key = Console.ReadLine();
                if (string.IsNullOrEmpty(key))
                {
                    continue;
                }
                if (new[] { "x", "х" }.Contains(key))
                {
                    break;
                }
                product.Description = key;
            } while (string.IsNullOrEmpty(product.Description));
            do
            {
                Console.WriteLine("Input product price.");
                key = Console.ReadLine();
                if (string.IsNullOrEmpty(key) || !float.TryParse(key, out float price))
                {
                    Console.WriteLine("Incorrect input");
                    continue;
                }
                product.Price = price;
            } while (product.Price == 0.0f);

            do
            {
                Console.WriteLine("Input product quantity or x to skip");
                key = Console.ReadLine();
                if (new[] { "x", "х" }.Contains(key))
                {
                    break;
                }
                if (string.IsNullOrEmpty(key)  || !int.TryParse(key, out int qa))
                {
                    Console.WriteLine("Incorrect input");
                    continue;
                }
                product.Quantity = qa;
            } while (product.Quantity == 1);


            return product;
        }

        public void NewQuantity(int qa)
        {
            this.Quantity = qa;
        }

        public void ReduceQuantity()
        {
            if (this.Quantity > 0)
            {
                this.Quantity--;
            }
        }
    }

}
