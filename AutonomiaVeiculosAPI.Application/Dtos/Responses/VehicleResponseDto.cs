using AutonomiaVeiculosAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Application.Dtos.Responses
{
    public class VehicleResponseDto
    {
        public int IdVehicle { get; set; }
        public string? VehicleModel { get; set; }
        public string? Fabricant { get; set; }
        public string? Color { get; set; }
        public int Autonomy { get; set; }

        // Chave estrangeira
        public int IdFuelType { get; set; }
        // Propriedade de navegação para o tipo associado (um veículo tem um tipo)
        public FuelTypeResponseDto? Type { get; set; }
    }
}
