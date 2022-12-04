using Microsoft.AspNetCore.Mvc;
using ShopProductsWebApp.Models;
using System.Diagnostics;

namespace ShopProductsWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View("MyView");
        }

        public ViewResult ProductForm()
        {
            return View("Form");
        }
    }
}