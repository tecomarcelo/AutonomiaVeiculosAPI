using AutonomiaVeiculosAPI.Domain.Interfaces.Repositories;
using AutonomiaVeiculosAPI.Domain.Models;
using AutonomiaVeiculosAPI.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Infra.Data.Repositories
{
    public class FuelingRepository : BaseRepository<Fueling, int>, IFuelingRepository
    {
        private readonly DataContext _dataContext;

        public FuelingRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        // GetAll específico abastecimento
        public new List<Fueling> GetAll()
        {
            return _dataContext.Set<Fueling>()
                               .Include(v => v.User)
                               .ToList();
        }

        public new Fueling? GetById(int id)
        {
            return _dataContext.Set<Fueling>()
                               .Include(v => v.User)
                               .SingleOrDefault(v => v.IdFueling == id);
        }

        public async Task<IEnumerable<Fueling>> GetFuelingsBetweenDatesAsync(DateOnly startDate, DateOnly endDate, int? vehicleId)
        {
            var query = _dataContext.Set<Fueling>()
                .Where(f => f.FuelingDate >= startDate && f.FuelingDate <= endDate);

            if (vehicleId.HasValue)
            {
                query = query.Where(f => f.IdVehicle == vehicleId.Value);
            }

            // .AsNoTracking() para consultas de leitura pura para melhor performance
            return await query.AsNoTracking().ToListAsync();
        }
    }
}
