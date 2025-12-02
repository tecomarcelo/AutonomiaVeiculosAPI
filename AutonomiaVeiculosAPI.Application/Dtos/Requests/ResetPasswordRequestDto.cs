using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Application.Dtos.Requests
{
    public class ResetPasswordRequestDto
    {
        [Required(ErrorMessage = "Informe a senha de acesso atual.")]
        public string? CurrentPassword { get; set; }

        [Required(ErrorMessage = "Informe a nova senha de acesso.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$",
            ErrorMessage = "Informe uma senha forte com pelo menos 8 caracteres, letras maiusculas/minuscular, número e caracter especial.")]
        public string? NewPassword { get; set; }

        [Required(ErrorMessage = "Informe a nova senha de acesso.")]
        [Compare("NewPassword", ErrorMessage = "Senhas não conferem.")]
        public string? NewPasswordConfirm { get; set; }
    }
}
