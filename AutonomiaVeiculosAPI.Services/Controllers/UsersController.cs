using AutonomiaVeiculosAPI.Application.Dtos.Requests;
using AutonomiaVeiculosAPI.Application.Dtos.Responses;
using AutonomiaVeiculosAPI.Application.Interfaces;
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
        [ProducesResponseType(typeof(UserResponseDto), 201)]
        public IActionResult Add([FromBody] UserAddRequestDto dto)
        {
            return StatusCode(201, _userAppService?.Add(dto));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UserResponseDto), 200)]
        public IActionResult Update(Guid id, [FromBody] UserUpdateRequestDto dto)
        {
            return StatusCode(201, _userAppService?.Update(id, dto));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<UserResponseDto>), 200)]
        public IActionResult Get(Guid id)
        {
            return StatusCode(200, _userAppService.Get(id));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserResponseDto>), 200)]
        public IActionResult GetAll()
        {
            return StatusCode(200, _userAppService.GetAll());
        }
    }
}
