using AutonomiaVeiculosAPI.Domain.Exceptions;
using AutonomiaVeiculosAPI.Domain.Interfaces.Messages;
using AutonomiaVeiculosAPI.Domain.Interfaces.Repositories;
using AutonomiaVeiculosAPI.Domain.Interfaces.Security;
using AutonomiaVeiculosAPI.Domain.Interfaces.Services;
using AutonomiaVeiculosAPI.Domain.Models;
using AutonomiaVeiculosAPI.Domain.ValueObjects;
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
        private readonly IUserMessageProducer? _userMessageProducer;
        private readonly ITokenService? _tokenService;

        public UserDomainService(IUnitOfWork? unitOfWork, IUserMessageProducer? userMessageProducer, ITokenService? tokenService)
        {
            _unitOfWork = unitOfWork;
            _userMessageProducer = userMessageProducer;
            _tokenService = tokenService;
        }

        public void Add(User user)
        {
            if (Get(user.Email) != null)
                throw new EmailAlreadyExistsException(user.Email);

            _unitOfWork?.UserRepository.Add(user);
            _unitOfWork?.SaveChanges();

            _userMessageProducer?.Send(new UserMessageVO
            {
                Id = user.Id,
                SendedAt = DateTime.Now,
                To = user.Email,
                Subject = "Parabéns, sua conta de usuário foi criada com sucesso!",
                Body = $@"Olá {user.Name}, seu cadastro foi realizado com sucesso em nosso sistema."
            });
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
            var user = Get(email, password);

            if (user == null)
                throw new AccessDeniedException();

            var userAuth = new UserAuthVO()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = "USER_ROLE", //perfil do usuário
                SignedAt = DateTime.Now,
            };

            return _tokenService?.CreateToken(userAuth);
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
