using AutoMapper;
using AutonomiaVeiculosAPI.Application.Dtos.Requests;
using AutonomiaVeiculosAPI.Application.Dtos.Responses;
using AutonomiaVeiculosAPI.Application.Interfaces;
using AutonomiaVeiculosAPI.Application.Shared;
using AutonomiaVeiculosAPI.Domain.Interfaces.Services;
using AutonomiaVeiculosAPI.Domain.Models;
using AutonomiaVeiculosAPI.Domain.Services;
using System.Linq.Expressions;

namespace AutonomiaVeiculosAPI.Application.Services
{
    public class FuelingAppService : IFuelingAppService
    {
        private readonly IMapper _mapper;
        private readonly IFuelingDomainService? _fuelingDomainService;
        private readonly ICurrentUserService? _currentUserService;

        public FuelingAppService(IMapper mapper, IFuelingDomainService? fuelingDomainService, ICurrentUserService? currentUserService)
        {
            _mapper = mapper;
            _fuelingDomainService = fuelingDomainService;
            _currentUserService = currentUserService;
        }

        public FuelingResponseDto Add(FuelingAddRequestDto dto)
        {
            var userId = _currentUserService?.GetUserId();

            var fueling = new Fueling
            {
                TypeFuel = dto.TypeFuel,
                Quantity = dto.Quantity,
                FuelingDate = dto.FuelingDate,
                CorrentKm = dto.CorrentKm,
                FuelingCosts = dto.FuelingCosts,
                IdVehicle = dto.IdVehicle,
                IdUser = userId!.Value
            };

            _fuelingDomainService?.Add(fueling);

            return _mapper.Map<FuelingResponseDto>(fueling);
        }

        public FuelingResponseDto Update(int id, FuelingUpdateRequestDto dto)
        {
            var userId = _currentUserService?.GetUserId();

            var fueling = _fuelingDomainService?.GetById(id);

            fueling!.TypeFuel = dto.TypeFuel;
            fueling.Quantity = dto.Quantity;
            fueling.FuelingDate = dto.FuelingDate;
            fueling.CorrentKm = dto.CorrentKm;
            fueling.FuelingCosts = dto.FuelingCosts;
            fueling.IdVehicle = dto.IdVehicle;
            fueling.IdUser = userId!.Value;

            _fuelingDomainService?.Update(fueling);

            return _mapper.Map<FuelingResponseDto>(fueling);
        }

        public FuelingResponseDto Delete(int id)
        {
            var fueling = _fuelingDomainService?.GetById(id);
            _fuelingDomainService?.Delete(fueling!);

            return _mapper.Map<FuelingResponseDto>(fueling);
        }
        
        public FuelingResponseDto Get(int id)
        {
            var fueling = _fuelingDomainService?.GetById(id);

            return _mapper.Map<FuelingResponseDto>(fueling);
        }

        public IEnumerable<FuelingResponseDto> GetAll()
        {
            var userId = _currentUserService?.GetUserId();
            if (userId == null)
            {
                // Tratar caso o usuário o ID seja inválido
                return Enumerable.Empty<FuelingResponseDto>();
            }

            // expressão condicional (where clause)
            Expression<Func<Fueling, bool>> userFilter = f => f.IdUser == userId.Value;

            // método GetAll com o filtro
            var fuelings = _fuelingDomainService?.GetAll(userFilter);

            return _mapper.Map<IEnumerable<FuelingResponseDto>>(fuelings);
        }
        
        public void Dispose()
        {
            _fuelingDomainService?.Dispose();
        }
    }
}
