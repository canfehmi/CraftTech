using CraftTech.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CraftTech.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        [HttpPost("[action]")]
        public IActionResult Login(LoginModel model)
        {
            if (model.Username == "admin" && model.Password == "password")
            {
                return Ok(new CreateToken().TokenCreate());
            }
            return Unauthorized();
        }

    }
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
