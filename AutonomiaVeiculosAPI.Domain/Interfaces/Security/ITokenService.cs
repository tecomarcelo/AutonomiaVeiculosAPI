using AutonomiaVeiculosAPI.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Domain.Interfaces.Security
{
    public interface ITokenService
    {
        string CreateToken(UserAuthVO userAuth);
    }
}
