using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Domain.Models
{
    public class Type
    {
        public int IdType { get; set; }
        public string? VehicleType { get; set; }

        #region
        // Propriedade de navegação para a coleção de veículos (um tipo tem muitos veículos)
        public ICollection<Vehicles> Vehicles { get; set; } = new List<Vehicles>();
        #endregion
    }
}
