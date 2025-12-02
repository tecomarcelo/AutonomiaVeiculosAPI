using AutoMapper;
using AutonomiaVeiculosAPI.Application.Dtos.Requests;
using AutonomiaVeiculosAPI.Application.Dtos.Responses;
using AutonomiaVeiculosAPI.Application.Interfaces;
using AutonomiaVeiculosAPI.Domain.Interfaces.Services;
using AutonomiaVeiculosAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Application.Services
{
    public class FuelingAppService : IFuelingAppService
    {
        private readonly IMapper? _mapper;
        private readonly IFuelingDomainService? _fuelingDomainService;

        public FuelingAppService(IMapper? mapper, IFuelingDomainService? fuelingDomainService)
        {
            _mapper = mapper;
            _fuelingDomainService = fuelingDomainService;
        }

        public FuelingResponseDto Add(FuelingAddRequestDto dto)
        {
            var fueling = new Fueling
            {
                TypeFuel = dto.TypeFuel,
                Quantity = dto.Quantity,
                FuelingDate = dto.FuelingDate,
                CorrentKm = dto.CorrentKm
            };

            _fuelingDomainService?.Add(fueling);

            return _mapper.Map<FuelingResponseDto>(fueling);
        }

        public FuelingResponseDto Update(int id, FuelingUpdateRequestDto dto)
        {
            var fueling = new Fueling
            {
                TypeFuel = dto.TypeFuel,
                Quantity = dto.Quantity,
                FuelingDate = dto.FuelingDate,
                CorrentKm = dto.CorrentKm
            };

            _fuelingDomainService?.Update(fueling);

            return _mapper.Map<FuelingResponseDto>(fueling);
        }

        public FuelingResponseDto Delete(int id)
        {
            var fueling = _fuelingDomainService?.GetById(id);
            _fuelingDomainService?.Delete(fueling);

            return _mapper.Map<FuelingResponseDto>(fueling);
        }
        
        public FuelingResponseDto Get(int id)
        {
            var fueling = _fuelingDomainService?.GetById(id);

            return _mapper.Map<FuelingResponseDto>(fueling);
        }

        public IEnumerable<FuelingResponseDto> GetAll()
        {
            var fuelings = _fuelingDomainService?.GetAll();

            return _mapper.Map<IEnumerable<FuelingResponseDto>>(fuelings);
        }
        
        public void Dispose()
        {
            _fuelingDomainService?.Dispose();
        }
    }
}
