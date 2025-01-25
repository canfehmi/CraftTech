using CraftTech.WebUI.Areas.Admin.Models.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CraftTech.WebUI.Areas.Admin.Controllers
{
    [Authorize]
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
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://api.craftechmuhendislik.com/api/Product");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ProductResultDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductCreateDto productCreateDto, IFormFile file)
        {
            if(!ModelState.IsValid)
            {
                return View(productCreateDto);
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
                productCreateDto.ImageUrl = "https://admin.craftechmuhendislik.com/images/" + fileName;
            }
            var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(productCreateDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://api.craftechmuhendislik.com/api/Product", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(productCreateDto);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://api.craftechmuhendislik.com/api/Product/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var value= JsonConvert.DeserializeObject<ProductUpdateDto>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductUpdateDto productUpdateDto, IFormFile? file)
        {
            if (!ModelState.IsValid)
            {
                return View(productUpdateDto);
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
                productUpdateDto.ImageUrl = "https://admin.craftechmuhendislik.com/images/" + fileName;
            }
            var client= _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(productUpdateDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("https://api.craftechmuhendislik.com/api/Product", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(productUpdateDto);
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://api.craftechmuhendislik.com/api/Product/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
