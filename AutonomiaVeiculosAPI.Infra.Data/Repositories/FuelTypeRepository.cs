using AutonomiaVeiculosAPI.Domain.Interfaces.Repositories;
using AutonomiaVeiculosAPI.Domain.Models;
using AutonomiaVeiculosAPI.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Infra.Data.Repositories
{
    public class FuelTypeRepository : BaseRepository<FuelType, int>, IFuelTypeRepository
    {
        private readonly DataContext? _dataContext;

        public FuelTypeRepository(DataContext? dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
