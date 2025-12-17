using System.ComponentModel.DataAnnotations;

namespace AutonomiaVeiculosAPI.Application.Dtos.Requests
{
    public class FuelingReportAddRequestDto : IValidatableObject
    {
        [Required]
        public DateOnly StartDate { get; set; }

        [Required]
        public DateOnly EndDate { get; set; }

        // relatório for por veículo
        [Required]
        public int? VehicleId { get; set; }

        public IEnumerable<ValidationResult> Validate(
        ValidationContext validationContext)
        {
            if (EndDate <= StartDate)
            {
                yield return new ValidationResult(
                    "A data final deve ser maior que a data inicial.",
                    new[] { nameof(EndDate) });
            }
        }
    }
}
