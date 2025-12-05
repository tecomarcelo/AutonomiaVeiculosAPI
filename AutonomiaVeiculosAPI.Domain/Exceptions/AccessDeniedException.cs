using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AutonomiaVeiculosAPI.Domain.Exceptions
{
    public class AccessDeniedException : Exception
    {
        public override string Message => "Acesso negado. Usuário o senha inválidos.";
    }    
}
