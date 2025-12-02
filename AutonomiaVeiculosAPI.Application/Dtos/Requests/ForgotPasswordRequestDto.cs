using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Application.Dtos.Requests
{
    public class ForgotPasswordRequestDto
    {
        [Required(ErrorMessage = "Informe o email de acesso.")]
        [EmailAddress(ErrorMessage = "Informe um endereço de email válido.")]
        public string? Email { get; set; }
    }
}
