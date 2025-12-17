using AutonomiaVeiculosAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Domain.Interfaces.Repositories
{
    public interface IFuelingRepository : IBaseRepository<Fueling, int>
    {
        // consulta entre datas para EndPoint FuelingReport
        Task<IEnumerable<Fueling>> GetFuelingsBetweenDatesAsync(DateOnly startDate, DateOnly endDate, int? vehicleId);
    }
}
