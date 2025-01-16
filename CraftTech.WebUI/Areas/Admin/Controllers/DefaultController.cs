using Microsoft.AspNetCore.Mvc;

namespace CraftTech.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Sayfa()
        {
            return View();
        }
    }
}
