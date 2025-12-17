using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Application.Dtos.Responses
{
    public class FuelingReportResponseDto
    {
        public double KmPorLitro { get; set; }
        public double MediaDeLitros { get; set; }
        public int KmRodadoNoPeriodo { get; set; }
        public decimal TotalAbastecido { get; set; }
        public decimal CustoTotal { get; set; }
    }
}
