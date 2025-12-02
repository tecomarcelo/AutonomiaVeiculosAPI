using AutonomiaVeiculosAPI.Application.Dtos.Requests;
using AutonomiaVeiculosAPI.Application.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Application.Interfaces
{
    public interface IUserAppService : IDisposable
    {
        UserResponseDto Add(UserAddRequestDto dto);
        UserResponseDto Update(Guid id, UserUpdateRequestDto dto);
        UserResponseDto Delete(Guid id);
        UserResponseDto Get(Guid id);
    }
}
