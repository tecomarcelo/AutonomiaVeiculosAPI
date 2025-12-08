using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime CreatedAt { get; set; }

        #region
        // Propriedade de navegação para a coleção de veículos (um usuário tem muitos abastecimentos)
        public ICollection<Fueling> Fuelings { get; set; } = new List<Fueling>();
        #endregion
    }
}
