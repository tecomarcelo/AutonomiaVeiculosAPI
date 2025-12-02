using AutonomiaVeiculosAPI.Application.Dtos.Responses;
using AutonomiaVeiculosAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Application.Interfaces
{
    public interface IFuelTypeAppService : IDisposable
    {
        FuelTypeResponseDto Get(int id);
        IEnumerable<FuelTypeResponseDto> GetAll();
    }
}
