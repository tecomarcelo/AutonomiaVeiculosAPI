using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Domain.Exceptions
{
    public class VehicleNotFoundException : Exception
    {
        public override string Message => "Não foi encontrado Veiculo com este ID.";
    }
}
