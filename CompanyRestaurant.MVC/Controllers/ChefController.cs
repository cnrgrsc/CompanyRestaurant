using Microsoft.AspNetCore.Mvc;

namespace CompanyRestaurant.MVC.Controllers
{
    public class ChefController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
