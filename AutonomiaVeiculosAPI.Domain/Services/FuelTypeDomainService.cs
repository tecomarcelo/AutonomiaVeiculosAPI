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
    public class FuelTypeDomainService : IFuelTypeDomainService
    {
        private readonly IUnitOfWork? _unitOfWork;

        public FuelTypeDomainService(IUnitOfWork? unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(FuelType entity)
        {
            _unitOfWork.FuelTypeRepository.Add(entity);
            _unitOfWork.SaveChanges();
        }

        public void Update(FuelType entity)
        {
            _unitOfWork?.FuelTypeRepository.Update(entity);
            _unitOfWork?.SaveChanges();
        }

        public void Delete(FuelType entity)
        {
            _unitOfWork?.FuelTypeRepository.Delete(entity);
            _unitOfWork?.SaveChanges();
        }

        public FuelType? GetById(int id)
        {
            return _unitOfWork?.FuelTypeRepository.GetById(id);
        }

        public FuelType? Get(Expression<Func<FuelType, bool>> where)
        {
            return _unitOfWork?.FuelTypeRepository.Get(where);
        }

        public List<FuelType> GetAll()
        {
            return _unitOfWork?.FuelTypeRepository.GetAll();
        }

        public List<FuelType> GetAll(Expression<Func<FuelType, bool>> where)
        {
            return _unitOfWork?.FuelTypeRepository.GetAll(where);
        }             

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
