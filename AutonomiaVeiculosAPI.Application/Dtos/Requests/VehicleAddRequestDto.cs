using AutonomiaVeiculosAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Application.Dtos.Requests
{
    public class VehicleAddRequestDto
    {
        [Required(ErrorMessage = "Informe o modelo do veículo.")]
        public string? VehicleModel { get; set; }

        [Required(ErrorMessage = "Informe o fabricante do veículo.")]
        public string? Fabricant { get; set; }

        [Required(ErrorMessage = "Informe a car do veículo.")]
        public string? Color { get; set; }

        [Required(ErrorMessage = "Informe a autonomia do veículo.")]
        public int Autonomy { get; set; }

        // Chave estrangeira
        [Required(ErrorMessage = "Informe o tipo de combustível do veículo.")]
        public int IdFuelType { get; set; }
    }
}
