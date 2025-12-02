using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IVehiclesRepository VehiclesRepository { get; }
        IFuelingRepository FuelingRepository { get; }
        IFuelTypeRepository FuelTypeRepository { get; }

        void SaveChanges();
    }
}
