using AutonomiaVeiculosAPI.Domain.Interfaces.Repositories;
using AutonomiaVeiculosAPI.Domain.Models;
using AutonomiaVeiculosAPI.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Infra.Data.Repositories
{
    public class VehicleRepository : BaseRepository<Vehicle, int>, IVehiclesRepository
    {
        private readonly DataContext _dataContext;

        public VehicleRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        // GetAll específico veiculo
        public new List<Vehicle> GetAll()
        {
            // Use _dataContext.Vehicles ou _dataContext.Set<Vehicle>() se preferir
            return _dataContext.Set<Vehicle>()
                               .Include(v => v.Type)
                               .ToList();
        }

        public new Vehicle? GetById(int id)
        {
            return _dataContext.Set<Vehicle>()
                               .Include(v => v.Type)
                               .SingleOrDefault(v => v.IdVehicle == id);
        }
    }
}
