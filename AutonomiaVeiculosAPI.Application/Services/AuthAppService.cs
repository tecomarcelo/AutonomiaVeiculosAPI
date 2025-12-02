using AutoMapper;
using AutonomiaVeiculosAPI.Application.Dtos.Requests;
using AutonomiaVeiculosAPI.Application.Dtos.Responses;
using AutonomiaVeiculosAPI.Application.Interfaces;
using AutonomiaVeiculosAPI.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Application.Services
{
    public class AuthAppService : IAuthAppService
    {
        private readonly IMapper _mapper;
        private readonly IUserDomainService _userDomainService;

        public AuthAppService(IMapper mapper, IUserDomainService userDomainService)
        {
            _mapper = mapper;
            _userDomainService = userDomainService;
        }

        public LoginResponseDto Login(LoginRequestDto dto)
        {
            var user = _userDomainService?.Get(dto.Email, dto.Password);
            //TODO Implementar a autenticação do usuário.
            return new LoginResponseDto
            {
                AccessToken = string.Empty,
                Expiration = DateTime.Now,
                User = _mapper.Map<UserResponseDto>(user)
            };

        }

        public UserResponseDto ForgotPassword(ForgotPasswordRequestDto dto)
        {
            var user = _userDomainService?.Get(dto.Email);
            //TODO Implementar a recuperação da senha do usuário
            return _mapper.Map<UserResponseDto>(user);
        }

        public UserResponseDto ResetPassword(Guid id, ResetPasswordRequestDto dto)
        {
            var user = _userDomainService?.Get(id);
            //TODO implentar autualização de senha do usuário
            return _mapper.Map<UserResponseDto>(user);
        }

        public void Dispose()
        {
            _userDomainService?.Dispose();
        }
    }
}
