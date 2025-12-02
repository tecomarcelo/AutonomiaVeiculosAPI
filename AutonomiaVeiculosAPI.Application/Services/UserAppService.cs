using AutoMapper;
using AutonomiaVeiculosAPI.Application.Dtos.Requests;
using AutonomiaVeiculosAPI.Application.Dtos.Responses;
using AutonomiaVeiculosAPI.Application.Interfaces;
using AutonomiaVeiculosAPI.Domain.Exceptions;
using AutonomiaVeiculosAPI.Domain.Interfaces.Services;
using AutonomiaVeiculosAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IMapper? _mapper;
        private readonly IUserDomainService? _userDomainService;

        public UserAppService(IMapper? mapper, IUserDomainService? userDomainService)
        {
            _mapper = mapper;
            _userDomainService = userDomainService;
        }

        public UserResponseDto Add(UserAddRequestDto dto)
        {
            try
            {
                var user = new User
                {
                    Id = Guid.NewGuid(),
                    Name = dto.Name,
                    Email = dto.Email,
                    Password = dto.Password,
                    CreatedAt = DateTime.Now
                };

                _userDomainService?.Add(user);
                return _mapper.Map<UserResponseDto>(user);
            }
            catch(EmailAlreadyExistsException e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public UserResponseDto Update(Guid id, UserUpdateRequestDto dto)
        {
            var user = _userDomainService?.Get(id);
            user.Name = dto.Name;

            _userDomainService?.Update(user);
            return _mapper.Map<UserResponseDto>(user);
        }

        public UserResponseDto Delete(Guid id)
        {
            var user = _userDomainService?.Get(id);

            _userDomainService?.Delete(user);
            return _mapper.Map<UserResponseDto>(user);
        }

        public UserResponseDto Get(Guid id)
        {
            var user = _userDomainService?.Get(id);

            return _mapper.Map<UserResponseDto>(user);
        }

        public IEnumerable<UserResponseDto> GetAll()
        {
            var users = _userDomainService?.GetAll();
            return _mapper.Map<IEnumerable<UserResponseDto>>(users);
        }

        public void Dispose()
        {
            _userDomainService?.Dispose();
        }
    }
}
