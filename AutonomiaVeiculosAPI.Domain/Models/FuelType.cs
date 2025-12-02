using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Domain.Models
{
    public class FuelType
    {
        [Key]
        public int IdFuelType { get; set; }
        public string? VehicleType { get; set; }

        #region
        // Propriedade de navegação para a coleção de veículos (um tipo tem muitos veículos)
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        #endregion
    }
}
