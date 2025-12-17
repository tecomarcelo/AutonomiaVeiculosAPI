using AutonomiaVeiculosAPI.Application.Dtos.Requests;
using AutonomiaVeiculosAPI.Application.Dtos.Responses;
using AutonomiaVeiculosAPI.Application.Interfaces;
using AutonomiaVeiculosAPI.Domain.Interfaces.Repositories;

namespace AutonomiaVeiculosAPI.Application.Services
{
    public class FuelingReportAppService : IFuelingReportAppService
    {
        private readonly IFuelingRepository _fuelingRepository;

        public FuelingReportAppService(IFuelingRepository fuelingRepository)
        {
            _fuelingRepository = fuelingRepository;
        }

        public async Task<FuelingReportResponseDto> GetFuelingReportAsync(FuelingReportAddRequestDto queryParams)
        {
            var fuelingRecords = await _fuelingRepository.GetFuelingsBetweenDatesAsync(
                queryParams.StartDate,
                queryParams.EndDate,
                queryParams.VehicleId
            );

            if (fuelingRecords == null || !fuelingRecords.Any())
            {
                return new FuelingReportResponseDto(); // Retorna um relatório vazio ou nulo
            }

            // Realizando os cálculos
            var firstKm = fuelingRecords.OrderBy(f => f.FuelingDate).First().CorrentKm;
            var lastKm = fuelingRecords.OrderBy(f => f.FuelingDate).Last().CorrentKm;
            var totalQuantity = fuelingRecords.Sum(f => f.Quantity);
            var totalCost = fuelingRecords.Sum(f => f.FuelingCosts);

            var kmRodado = lastKm - firstKm;
            var mediaLitros = (double)totalQuantity / fuelingRecords.Count();
            var kmPorLitro = (double)kmRodado / totalQuantity;

            return new FuelingReportResponseDto
            {
                KmRodadoNoPeriodo = kmRodado,
                TotalAbastecido = totalQuantity,
                CustoTotal = totalCost,
                MediaDeLitros = Math.Round(mediaLitros, 2),
                KmPorLitro = Math.Round(kmPorLitro, 2)
            };
        }
    }
}
