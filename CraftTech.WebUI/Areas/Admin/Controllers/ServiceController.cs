using CraftTech.WebUI.Areas.Admin.Models.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CraftTech.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IWebHostEnvironment env;

        public ServiceController(IHttpClientFactory httpClientFactory, IWebHostEnvironment env)
        {
            _httpClientFactory = httpClientFactory;
            this.env = env;
        }

        public async Task< IActionResult> Index()
        {
            var client= _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://craftechmuhendislik.com/api/Service");
            if(response.IsSuccessStatusCode)
            {
                var jsonData= await response.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<List<ServiceResultDto>>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddService(ServiceCreateDto serviceCreateDto, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return View(serviceCreateDto);
            }
            if (file != null)
            {
                var uploadsFolder = Path.Combine(env.WebRootPath, "images");
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                serviceCreateDto.ImageURL = "/images/" + fileName;
            }
            var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(serviceCreateDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8,"application/json");
            var response = await client.PostAsync("https://craftechmuhendislik.com/api/Service", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(serviceCreateDto);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var client= _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://craftechmuhendislik.com/api/Service/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData= await response.Content.ReadAsStringAsync();
                var value= JsonConvert.DeserializeObject<ServiceUpdateDto>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateService(ServiceUpdateDto serviceUpdateDto, IFormFile? file)
        {
            if (!ModelState.IsValid)
            {
                return View(serviceUpdateDto);
            }
            if (file != null)
            {
                var uploadsFolder = Path.Combine(env.WebRootPath, "images");
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                serviceUpdateDto.ImageURL = "/images/" + fileName;
            }
            var client= _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(serviceUpdateDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8,"application/json");
            var response = await client.PutAsync("https://craftechmuhendislik.com/api/Service", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(serviceUpdateDto);
        }
        public async Task<IActionResult> DeleteService(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://craftechmuhendislik.com/api/Service/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
