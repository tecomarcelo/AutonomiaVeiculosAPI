using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Domain.Models
{
    public class Fueling
    {
        [Key]
        public int IdFueling { get; set; }
        public int? TypeFuel { get; set; }
        public int Quantity { get; set; }
        public DateOnly FuelingDate { get; set; }
        public int CorrentKm { get; set; }

        #region
        // Chave estrangeira
        public Guid UserId { get; set; }
        // Propriedade de navegação para o tipo associado (um Abastecimento tem um Usuário)
        public User? User { get; set; }
        #endregion
    }
}
