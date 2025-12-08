using AutonomiaVeiculosAPI.Application.Dtos.Requests;
using AutonomiaVeiculosAPI.Application.Dtos.Responses;
using AutonomiaVeiculosAPI.Application.Interfaces;
using AutonomiaVeiculosAPI.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;

namespace AutonomiaVeiculosAPI.Services.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FuelingController : ControllerBase
    {
        private readonly IFuelingAppService? _fuelingAppService;

        public FuelingController(IFuelingAppService? fuelingAppService)
        {
            _fuelingAppService = fuelingAppService;
        }

        /// <summary>
        /// Entrar com dados do abastecimento
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(FuelingResponseDto), 201)]
        public IActionResult Post([FromBody] FuelingAddRequestDto dto)
        {
            return StatusCode(201, _fuelingAppService?.Add(dto));
        }

        [HttpPut]
        [ProducesResponseType(typeof(FuelingResponseDto), 200)]
        public IActionResult Put(int id, [FromBody] FuelingUpdateRequestDto dto)
        {
            return StatusCode(200, _fuelingAppService?.Update(id, dto));
        }

        [HttpDelete]
        [ProducesResponseType(typeof(FuelingResponseDto), 200)]
        public IActionResult Delete(int id)
        {
            return StatusCode(200, _fuelingAppService?.Delete(id));
        }

        [HttpGet ("{id}")]
        [ProducesResponseType(typeof(FuelingResponseDto), 200)]
        public IActionResult Get(int id)
        {
            return StatusCode(200, _fuelingAppService?.Get(id));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FuelingResponseDto>), 200)]
        public IActionResult Get()
        {
            return StatusCode(200, _fuelingAppService?.GetAll());
        }
    }
}
