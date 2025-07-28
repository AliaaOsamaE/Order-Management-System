using Microsoft.AspNetCore.Mvc;

namespace Order_Management_System.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
