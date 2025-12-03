using AutoMapper;
using AutonomiaVeiculosAPI.Application.Dtos.Requests;
using AutonomiaVeiculosAPI.Application.Dtos.Responses;
using AutonomiaVeiculosAPI.Application.Interfaces;
using AutonomiaVeiculosAPI.Domain.Exceptions;
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
            try
            {
                var accessToken = _userDomainService?.Authenticate(dto.Email, dto.Password);
                
                return new LoginResponseDto
                {
                    AccessToken = accessToken,
                };

            }
            catch(AccessDeniedException e)
            {
                throw new ApplicationException(e.Message);
            }
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
