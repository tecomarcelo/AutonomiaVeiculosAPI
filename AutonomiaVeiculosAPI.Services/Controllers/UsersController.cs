using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutonomiaVeiculosAPI.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Add()
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Update()
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
