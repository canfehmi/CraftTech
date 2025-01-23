using CraftTech.DataAccessLayer.Concrete;
using CraftTech.WebUI.Areas.Admin.Models.Message;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CraftTech.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MessageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://craftechmuhendislik.com/api/Message");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<MessageResultDto>>(jsonData);
                if (values != null)
                {
                    var sortedValues = values.OrderByDescending(u => u.MessageID).ToList();
                    return View(sortedValues);
                }
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> MessageDetail(int id)
        {
            Context context = new Context();
            var mess = context.Messages.FirstOrDefault(u=>u.MessageID == id);
            if (mess != null)
            {
                mess.IsRead = true;
                context.SaveChanges();
            }
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://craftechmuhendislik.com/api/Message/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<MessageResultDto>(jsonData);
                return View(value);
            }
            return View();
        }
        public async Task<IActionResult> NotRead()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://craftechmuhendislik.com/api/Message");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values= JsonConvert.DeserializeObject<List<MessageResultDto>>(jsonData);
                var notReadMessage = values.Where(u=>u.IsRead==false).OrderByDescending(u=>u.MessageID).ToList();
                return View(notReadMessage);
            }
            return View();
        }
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var client= _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://craftechmuhendislik.com/api/Message/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
