using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Domain.Models
{
    public class Vehicle
    {
        [Key]
        public int IdVehicle { get; set; }
        public string? VehicleModel { get; set; }
        public string? Fabricant { get; set; }
        public string? Color { get; set; }
        public int Autonomy { get; set; }

        #region
        // Chave estrangeira
        public int IdFuelType { get; set; }
        // Propriedade de navegação para o tipo associado (um veículo tem um tipo)
        public FuelType? Type { get; set; }
        #endregion
    }
}
