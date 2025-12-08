using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Application.Dtos.Responses
{
    public class FuelingResponseDto
    {
        public int IdFueling { get; set; }
        public int TypeFuel { get; set; }
        public int Quantity { get; set; }
        public DateOnly FuelingDate { get; set; }
        public int CorrentKm { get; set; }

        public Guid IdUser { get; set; }
    }
}
