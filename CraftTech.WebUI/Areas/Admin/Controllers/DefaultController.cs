using CraftTech.WebUI.Areas.Admin.Models.About;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CraftTech.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task< IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7117/api/AboutUs/1");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultAboutDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Index(ResultAboutDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7117/api/AboutUs", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AboutUs");
            }
            return View(dto);
        }
    }
}
