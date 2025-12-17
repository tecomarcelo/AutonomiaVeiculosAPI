using AutonomiaVeiculosAPI.Application.Dtos.Requests;
using AutonomiaVeiculosAPI.Application.Dtos.Responses;

namespace AutonomiaVeiculosAPI.Application.Interfaces
{
    public interface IFuelingReportAppService
    {
        Task<FuelingReportResponseDto> GetFuelingReportAsync(
        FuelingReportAddRequestDto queryParams);
    }
}
