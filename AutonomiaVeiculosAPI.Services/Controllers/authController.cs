using AutonomiaVeiculosAPI.Application.Dtos.Requests;
using AutonomiaVeiculosAPI.Application.Dtos.Responses;
using AutonomiaVeiculosAPI.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutonomiaVeiculosAPI.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class authController : ControllerBase
    {
        private readonly IAuthAppService? _authAppService;

        public authController(IAuthAppService? authAppService)
        {
            _authAppService = authAppService;
        }

        /// <summary>
        /// Autenticar o Usuário
        /// </summary>
        [Route("login")]
        [HttpPost]
        [ProducesResponseType(typeof(LoginResponseDto), 200)]
        public IActionResult Login(LoginRequestDto dto)
        {
            return StatusCode(200, _authAppService?.Login(dto));
        }

        /// <summary>
        /// Recuperar senha de acesso do usuário
        /// </summary>
        [Route("forgot-password")]
        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordRequestDto dto)
        {
            return Ok();
        }

        /// <summary>
        /// Alterar senha de acesso do usuário
        /// </summary>
        [Authorize]
        [Route("reset-password")]
        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordRequestDto dto)
        {
            return Ok();
        }
    }
}
