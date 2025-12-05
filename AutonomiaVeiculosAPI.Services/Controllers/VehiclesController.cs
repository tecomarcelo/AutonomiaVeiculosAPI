using AutonomiaVeiculosAPI.Application.Dtos.Requests;
using AutonomiaVeiculosAPI.Application.Dtos.Responses;
using AutonomiaVeiculosAPI.Application.Interfaces;
using AutonomiaVeiculosAPI.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutonomiaVeiculosAPI.Services.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleAppService? _vehicleAppService;

        public VehiclesController(IVehicleAppService? vehicleAppService)
        {
            _vehicleAppService = vehicleAppService;
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(VehicleResponseDto), 201)]
        public IActionResult Post([FromBody] VehicleAddRequestDto dto)
        {
            return StatusCode(201, _vehicleAppService?.Add(dto));
        }

        [HttpPut]
        [ProducesResponseType(typeof(VehicleResponseDto), 200)]
        public IActionResult Put(int id, [FromBody] VehicleUpdateRequestDto dto)
        {
            return StatusCode(200, _vehicleAppService?.Update(id, dto));
        }

        [HttpDelete]
        [ProducesResponseType(typeof(VehicleResponseDto), 200)]
        public IActionResult Delete(int id)
        {
            return StatusCode(200, _vehicleAppService?.Delete(id));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<VehicleResponseDto>), 200)]
        public IActionResult Get(int id)
        {
            return StatusCode(200, _vehicleAppService.Get(id));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<VehicleResponseDto>), 200)]
        public IActionResult GetAll()
        {
            return StatusCode(200, _vehicleAppService.GetAll());
        }
    }
}
