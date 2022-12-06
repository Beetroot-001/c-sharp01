using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop_Products_Site.Data;
using Shop_Products_Site.Models;

namespace Shop_Products_Site.Controllers
{
    [Route("products")]
    public class ProductsController : Controller
    {
        private readonly ProductsContext _productContext = new ProductsContext();

        // GET: ProductsController
        public ActionResult Index()
        {
            var products = _productContext.Products.ToList();

            return View(products); // запихаємо всі наші продукти в вюшку
        }

        [HttpGet("Create")]
        public ActionResult AddNewProduct()
        {
            return View();
        }

        [HttpGet("Create")]//далі в HTML братиметься там де метод щоб вибрати правильний метод
        public ActionResult AddNewProduct([FromForm] Product product)//[]явно показуємо звідки брати
        {
            if(ModelState.IsValid)
            {
                // перевірка на валідацію
            }

            _productContext.Products.Add(product);

            _productContext.SaveChanges();

            return RedirectToAction("Index");// створили і переходимо на першу сторінку
        }

        public ActionResult Delete12()
        {
            return View();
        }
    }
}
