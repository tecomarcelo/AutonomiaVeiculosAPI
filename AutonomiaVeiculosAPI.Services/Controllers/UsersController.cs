using AutonomiaVeiculosAPI.Application.Dtos.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutonomiaVeiculosAPI.Application.Interfaces;

namespace AutonomiaVeiculosAPI.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserAppService? _userAppService;

        public UsersController(IUserAppService? userAppService)
        {
            _userAppService = userAppService;
        }

        /// <summary>
        /// Criar conta de usuário
        /// </summary>        
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Add([FromBody] UserAddRequestDto dto)
        {
            return StatusCode(201, _userAppService?.Add(dto));
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
