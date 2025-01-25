using CraftTech.WebUI.Areas.Admin.Models.Banner;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CraftTech.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class BannerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public readonly IWebHostEnvironment env;

        public BannerController(IHttpClientFactory httpClientFactory, IWebHostEnvironment env)
        {
            _httpClientFactory = httpClientFactory;
            this.env = env;
        }
        public async Task< IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://api.craftechmuhendislik.com/api/Banner");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<BannerResultDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBanner(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://api.craftechmuhendislik.com/api/Banner/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var value= JsonConvert.DeserializeObject<BannerUpdateDto>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBanner(BannerUpdateDto bannerUpdateDto, IFormFile? file)
        {
            if (!ModelState.IsValid)
            {
                return View(bannerUpdateDto);
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
                bannerUpdateDto.ImageUrl = "https://admin.craftechmuhendislik.com/images/" + fileName;
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData= JsonConvert.SerializeObject(bannerUpdateDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://api.craftechmuhendislik.com/api/Banner", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(bannerUpdateDto);
        }
        [HttpGet]
        public IActionResult AddBanner()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBanner(BannerCreateDto bannerCreateDto, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return View(bannerCreateDto);
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
                bannerCreateDto.ImageUrl = "https://admin.craftechmuhendislik.com/images/" + fileName;
            }
            var client= _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(bannerCreateDto);
            StringContent content=new StringContent(jsonData,Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://api.craftechmuhendislik.com/api/Banner", content);
            if(responseMessage.IsSuccessStatusCode) 
            {
                return RedirectToAction("Index"); 
            }
            return View(bannerCreateDto);
        }
        public async Task<IActionResult> DeleteBanner(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://api.craftechmuhendislik.com/api/Banner/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
