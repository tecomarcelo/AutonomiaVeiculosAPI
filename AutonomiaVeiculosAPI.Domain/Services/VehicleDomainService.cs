using AutonomiaVeiculosAPI.Domain.Exceptions;
using AutonomiaVeiculosAPI.Domain.Interfaces.Repositories;
using AutonomiaVeiculosAPI.Domain.Interfaces.Services;
using AutonomiaVeiculosAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Domain.Services
{
    public class VehicleDomainService : IVehicleDomainService
    {
        private readonly IUnitOfWork _unityOfWork;

        public VehicleDomainService(IUnitOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public void Add(Vehicle entity)
        {
            _unityOfWork.VehiclesRepository.Add(entity);
            _unityOfWork.SaveChanges();
        }

        public void Update(Vehicle entity)
        {
            var vehicle = GetById(entity.IdVehicle);            

            _unityOfWork.VehiclesRepository.Update(entity);
            _unityOfWork.SaveChanges();
        }

        public void Delete(Vehicle entity)
        {
            _unityOfWork.VehiclesRepository.Delete(entity);
            _unityOfWork.SaveChanges();
        }        

        public Vehicle? GetById(int id)
        {
            var vehicle = _unityOfWork.VehiclesRepository.GetById(id);

            if (vehicle == null)
                throw new VehicleNotFoundException();

            return vehicle;

        }

        public Vehicle? Get(Expression<Func<Vehicle, bool>> where)
        {
            return _unityOfWork.VehiclesRepository.Get(where);
        }

        public List<Vehicle> GetAll()
        {
            return _unityOfWork.VehiclesRepository.GetAll();
        }

        public List<Vehicle> GetAll(Expression<Func<Vehicle, bool>> where)
        {
            return _unityOfWork.VehiclesRepository.GetAll(where);
        }
        
        public void Dispose()
        {
            _unityOfWork.Dispose();
        }
    }
}
