using Microsoft.AspNetCore.Mvc;

namespace BuildingCompanyMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
