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
        public string? TypeFuel { get; set; }
        public int Quantity { get; set; }
        public DateOnly FuelingDate { get; set; }
        public int CorrentKm { get; set; }
    }
}
