using Microsoft.AspNetCore.Mvc;

namespace Order_Management_System.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
