using AutonomiaVeiculosAPI.Application.Dtos.Requests;
using AutonomiaVeiculosAPI.Application.Dtos.Responses;
using AutonomiaVeiculosAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AutonomiaVeiculosAPI.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelingReportController : ControllerBase
    {
        private readonly IFuelingReportAppService _fuelingReportAppService;

        public FuelingReportController(IFuelingReportAppService fuelingReportAppService)
        {
            _fuelingReportAppService = fuelingReportAppService;
        }

        /// <summary>
        /// Resultados sobre o abastecimento
        /// </summary>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<FuelingReportResponseDto>> GetReport([FromQuery] FuelingReportAddRequestDto queryParams)
        {
            var reportDto = await _fuelingReportAppService.GetFuelingReportAsync(queryParams);

            // Verifica se retornou dados
            if (reportDto == null || reportDto.KmRodadoNoPeriodo == 0)
            {
                return NotFound("Nenhum relatório pôde ser gerado para o período especificado.");
            }

            return Ok(reportDto);
        }
    }
}
