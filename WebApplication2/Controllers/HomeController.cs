using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Authorize (Roles = "Admin")]
    [Route ("api/home")]
    public class HomeController : ControllerBase
    {
        
        [HttpGet]
        public string Index()
        {
            return "Hello World!";
        }
    }
}
