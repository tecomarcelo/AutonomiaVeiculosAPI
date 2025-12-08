using AutoMapper;
using AutonomiaVeiculosAPI.Application.Dtos.Responses;
using AutonomiaVeiculosAPI.Application.Interfaces;
using AutonomiaVeiculosAPI.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Application.Services
{
    public class FuelTypeAppService : IFuelTypeAppService
    {
        private readonly IMapper _mapper;
        private readonly IFuelTypeDomainService? _fuelTypeDomainService;

        public FuelTypeAppService(IMapper mapper, IFuelTypeDomainService? fuelTypeDomainService)
        {
            _mapper = mapper;
            _fuelTypeDomainService = fuelTypeDomainService;
        }
        
        public FuelTypeResponseDto Get(int id)
        {
            var fuelType = _fuelTypeDomainService?.GetById(id);

            return _mapper.Map<FuelTypeResponseDto>(fuelType);
        }

        public IEnumerable<FuelTypeResponseDto> GetAll()
        {
            var fueltypes = _fuelTypeDomainService?.GetAll();

            return _mapper.Map<IEnumerable<FuelTypeResponseDto>>(fueltypes);
        }

        public void Dispose()
        {
            _fuelTypeDomainService?.Dispose();
        }
    }
}
