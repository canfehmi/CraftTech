using Microsoft.AspNetCore.Mvc;

namespace CraftTech.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IWebHostEnvironment env;

        public ProductController(IHttpClientFactory httpClientFactory, IWebHostEnvironment env)
        {
            _httpClientFactory = httpClientFactory;
            this.env = env;
        }

        public async Task< IActionResult> Index()
        {
            return View();
        }
    }
}
