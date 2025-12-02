using AutonomiaVeiculosAPI.Domain.Interfaces.Repositories;
using AutonomiaVeiculosAPI.Domain.Interfaces.Services;
using AutonomiaVeiculosAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Domain.Services
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUnitOfWork? _unitOfWork;

        public UserDomainService(IUnitOfWork? unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(User user)
        {
            _unitOfWork?.UserRepository.Add(user);
            _unitOfWork?.SaveChanges();
        }

        public void Update(User user)
        {
            _unitOfWork?.UserRepository.Update(user);
            _unitOfWork?.SaveChanges();
        }

        public void Delete(User user)
        {
            _unitOfWork?.UserRepository.Delete(user);
            _unitOfWork?.SaveChanges();
        }        

        public User? Get(Guid id)
        {
            return _unitOfWork?.UserRepository.GetById(id);
        }

        public User? Get(string email)
        {
            return _unitOfWork?.UserRepository.Get(u => u.Email.Equals(email));
        }

        public User? Get(string email, string password)
        {
            return _unitOfWork?.UserRepository.Get(u => u.Email.Equals(email) && u.Password.Equals(password));
        }

        public IEnumerable<User> GetAll()
        {
            return _unitOfWork?.UserRepository.GetAll();
        }

        public string Authenticate(string email, string password)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
