using CraftTech.BussinessLayer.Abstract;
using CraftTech.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CraftTech.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private readonly IProcessService _processService;

        public ProcessController(IProcessService processService)
        {
            _processService = processService;
        }
        [HttpGet]
        public IActionResult ProcessList()
        {
            var values = _processService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddProcess(Process Process)
        {
            _processService.TInsert(Process);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProcess(int id)
        {
            var value = _processService.TGetById(id);
            _processService.TDelete(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateProcess(Process Process)
        {
            _processService.TUpdate(Process);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetProcess(int id)
        {
            var value = _processService.TGetById(id);
            return Ok(value);
        }
    }
}
