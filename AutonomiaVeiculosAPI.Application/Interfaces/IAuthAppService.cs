using AutonomiaVeiculosAPI.Application.Dtos.Requests;
using AutonomiaVeiculosAPI.Application.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Application.Interfaces
{
    public interface IAuthAppService : IDisposable
    {
        LoginResponseDto Login(LoginRequestDto dto);
        UserResponseDto ForgotPassword(ForgotPasswordRequestDto dto);
        UserResponseDto ResetPassword(Guid id, ResetPasswordRequestDto dto);
    }
}
