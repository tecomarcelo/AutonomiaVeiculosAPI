using System.ComponentModel.DataAnnotations;

namespace AutonomiaVeiculosAPI.Application.Dtos.Requests
{
    public class UserAddRequestDto
    {
        [Required(ErrorMessage = "Informe seu nome completo.")]
        [MinLength(8, ErrorMessage = "Informe um nome com pelo menos {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Informe um nome com no máximo {1} caracteres.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Informe o email de acesso.")]
        [EmailAddress(ErrorMessage = "Informe um endereço de email válido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Informe a senha de acesso.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$",
            ErrorMessage = "Informe uma senha forte com pelo menos 8 caracteres, letras maiusculas/minuscular, número e caracter especial.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Informe a senha de acesso.")]
        [Compare("Password", ErrorMessage = "Senhas não conferem.")]
        [DataType(DataType.Password)]
        public string? PasswordConfirm { get; set; }
    }
}
