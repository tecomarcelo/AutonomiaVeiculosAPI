using System.ComponentModel.DataAnnotations;

namespace AutonomiaVeiculosAPI.Application.Dtos.Requests
{
    public class FuelingAddRequestDto
    {
        [Required(ErrorMessage = "Informe o tipo de combustível.")]
        public int TypeFuel { get; set; }

        [Required(ErrorMessage = "Informe a quantidade.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Informe data do abastecimento.")]
        public DateOnly FuelingDate { get; set; }

        [Required(ErrorMessage = "Informe informe o km do momento do abastecimento.")]
        public int CorrentKm { get; set; }

        [Required(ErrorMessage = "Informe informe o Id do veículo.")]
        public int IdVehicle { get; set; }

        [Required(ErrorMessage = "Informe o custo da abastecimento.")]
        public decimal FuelingCosts { get; set; }
    }
}
