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
    public class FuelingDomainService : IFuelingDomainService
    {
        private readonly IUnitOfWork? _unitOfWork;

        public FuelingDomainService(IUnitOfWork? unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Fueling entity)
        {
            _unitOfWork?.FuelingRepository.Add(entity);
            _unitOfWork?.SaveChanges();
        }

        public void Update(Fueling entity)
        {
            _unitOfWork?.FuelingRepository.Update(entity);
            _unitOfWork?.SaveChanges();
        }

        public void Delete(Fueling entity)
        {
            _unitOfWork?.FuelingRepository.Delete(entity);
            _unitOfWork?.SaveChanges();
        }

        public Fueling? GetById(int id)
        {
            return _unitOfWork?.FuelingRepository.GetById(id);
        }

        public Fueling? Get(Expression<Func<Fueling, bool>> where)
        {
            return _unitOfWork?.FuelingRepository.Get(where);
        }

        public List<Fueling> GetAll()
        {
            return _unitOfWork.FuelingRepository.GetAll();
        }

        public List<Fueling> GetAll(Expression<Func<Fueling, bool>> where)
        {
            return _unitOfWork.FuelingRepository.GetAll(where);
        }        

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
