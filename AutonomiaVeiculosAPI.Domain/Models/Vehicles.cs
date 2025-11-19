using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Domain.Models
{
    public class Vehicles
    {
        public int IdVehicle { get; set; }
        public string? VehicleModel { get; set; }
        public string? Fabricant { get; set; }
        public string? Color { get; set; }
        public int Autonomy { get; set; }

        #region
        // Chave estrangeira
        public int IdType { get; set; }
        // Propriedade de navegação para o tipo associado (um veículo tem um tipo)
        public Type? Type { get; set; }
        #endregion
    }
}
