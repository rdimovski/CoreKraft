using Microsoft.AspNetCore.Mvc;

namespace Ccf.Ck.Launcher.Example.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}