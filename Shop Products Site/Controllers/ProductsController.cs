using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop_Products_Site.Data;
using Shop_Products_Site.Models;

namespace Shop_Products_Site.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductsContext _productsContext = new ProductsContext();

        // GET: ProductsController
        public ActionResult Index()
        {
            var products = _productsContext.Products.ToList();

            return View(products); 
        }

        [HttpGet("Create")]
        public ActionResult AddNewProduct()
        {
            return View();
        }

        [HttpGet("Create")]
        public ActionResult AddNewProduct([FromForm] Product product)
        {
            if(ModelState.IsValid)
            {
                // перевірка на валідацію
            }

            _productsContext.Products.Add(product);

            _productsContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet("[id]/delete")]
        public IActionResult Delete([FromRoute] int id)
        {
            var product = _productsContext.Products.Find(id);

            return View("Delete12", product);
        }

        [HttpPost("[id]/delete")]
        public ActionResult DeleteProduct([FromRoute] int id)
        {
            var product = _productsContext.Products.Find(id);

            if (product==null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                _productsContext.Products.Remove(product);

                _productsContext.SaveChanges();
            }

            return RedirectToAction("Delete");
        }
    }
}
