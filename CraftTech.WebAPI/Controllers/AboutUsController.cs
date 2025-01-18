using CraftTech.BussinessLayer.Abstract;
using CraftTech.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CraftTech.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsController : ControllerBase
    {
        private readonly IAboutUsService _aboutUsService;

        public AboutUsController(IAboutUsService aboutUsService)
        {
            _aboutUsService = aboutUsService;
        }
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "images/" + fileName);
            var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);
            return Created("", file);
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutUsService.TGetList();
            return Ok(values);
        }
        //[HttpPost]
        //public IActionResult AddAbout(AboutUs aboutUs)
        //{
        //    _aboutUsService.TInsert(aboutUs);
        //    return Ok();
        //}
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutUsService.TGetById(id);
            _aboutUsService.TDelete(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateAbout(AboutUs aboutUs)
        {
            _aboutUsService.TUpdate(aboutUs);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutUsService.TGetById(id);
            return Ok(value);
        }
    }
}
