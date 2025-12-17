namespace AutonomiaVeiculosAPI.Application.Dtos.Responses
{
    public class FuelingResponseDto
    {
        public int IdFueling { get; set; }
        public int TypeFuel { get; set; }
        public int Quantity { get; set; }
        public DateOnly FuelingDate { get; set; }
        public int CorrentKm { get; set; }
        public int IdVehicle { get; set; }
        public decimal FuelingCosts { get; set; }

        public Guid IdUser { get; set; }
    }
}
