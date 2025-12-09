using AutonomiaVeiculosAPI.Domain.Interfaces.Repositories;
using AutonomiaVeiculosAPI.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IUserRepository UserRepository => new UserRepository(_dataContext);
        public IVehiclesRepository VehiclesRepository => new VehicleRepository(_dataContext);
        public IFuelingRepository FuelingRepository => new FuelingRepository(_dataContext);
        public IFuelTypeRepository FuelTypeRepository => new FuelTypeRepository(_dataContext);

        public void SaveChanges()
        {
            _dataContext?.SaveChanges();
        }

        public void Dispose()
        {
            _dataContext?.Dispose();
        }
    }
}
