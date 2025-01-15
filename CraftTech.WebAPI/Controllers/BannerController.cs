using CraftTech.BussinessLayer.Abstract;
using CraftTech.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CraftTech.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly IBannerService _bannerService;

        public BannerController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }
        [HttpGet]
        public IActionResult BannerList()
        {
            var values = _bannerService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddBanner(Banner banner)
        {
            _bannerService.TInsert(banner);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateBanner(Banner banner)
        {
            _bannerService.TUpdate(banner);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBanner(int id)
        {
            var value = _bannerService.TGetById(id);
            _bannerService.TDelete(value);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetBanner(int id)
        {
            var value = _bannerService.TGetById(id);
            return Ok(value);
        }
    }
}
