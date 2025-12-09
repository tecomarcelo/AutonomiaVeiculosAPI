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
    }
}
