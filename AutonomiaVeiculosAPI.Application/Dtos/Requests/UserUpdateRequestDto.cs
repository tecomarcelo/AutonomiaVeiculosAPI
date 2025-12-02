using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Application.Dtos.Requests
{
    public class UserUpdateRequestDto
    {
        [Required(ErrorMessage = "Informe seu nome completo.")]
        [MinLength(8, ErrorMessage = "Informe um nome com pelo menos {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Informe um nome com no máximo {1} caracteres.")]
        public string? Name { get; set; }
    }
}
