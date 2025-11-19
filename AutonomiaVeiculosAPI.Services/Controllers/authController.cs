using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutonomiaVeiculosAPI.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class authController : ControllerBase
    {
        /// <summary>
        /// Autenticar o Usuário
        /// </summary>
        [Route("login")]
        [HttpPost]
        public IActionResult Login()
        {
            return Ok();
        }

        /// <summary>
        /// Recuperar senha de acesso do usuário
        /// </summary>
        [Route("forgot-password")]
        [HttpPost]
        public IActionResult ForgotPassword()
        {
            return Ok();
        }

        /// <summary>
        /// Alterar senha de acesso do usuário
        /// </summary>
        [Authorize]
        [Route("reset-password")]
        [HttpPost]
        public IActionResult ResetPassword()
        {
            return Ok();
        }
    }
}
