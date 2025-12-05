using AutoMapper;
using AutonomiaVeiculosAPI.Application.Dtos.Requests;
using AutonomiaVeiculosAPI.Application.Dtos.Responses;
using AutonomiaVeiculosAPI.Application.Interfaces;
using AutonomiaVeiculosAPI.Domain.Exceptions;
using AutonomiaVeiculosAPI.Domain.Interfaces.Repositories;
using AutonomiaVeiculosAPI.Domain.Interfaces.Services;
using AutonomiaVeiculosAPI.Domain.Models;

namespace AutonomiaVeiculosAPI.Application.Services
{
    public class VehicleAppService : IVehicleAppService
    {
        private readonly IMapper? _mapper;
        private readonly IVehicleDomainService? _vehicleDomainService;

        public VehicleAppService(IMapper? mapper, IVehicleDomainService? vehicleDomainService)
        {
            _mapper = mapper;
            _vehicleDomainService = vehicleDomainService;
        }

        public VehicleResponseDto Add(VehicleAddRequestDto dto)
        {
            var vehicle = new Vehicle
            {
                VehicleModel = dto.VehicleModel,
                Fabricant = dto.Fabricant,
                Color = dto.Color,
                Autonomy = dto.Autonomy,

                IdFuelType = dto.IdFuelType
            };

            _vehicleDomainService?.Add(vehicle);

            var completeVehicle = _vehicleDomainService?.GetById(vehicle.IdVehicle);

            return _mapper.Map<VehicleResponseDto>(completeVehicle);
        }

        public VehicleResponseDto Update(int id, VehicleUpdateRequestDto dto)
        {
            try
            {
                var vehicle = _vehicleDomainService?.GetById(id);

                vehicle.VehicleModel = dto.VehicleModel;
                vehicle.Fabricant = dto.Fabricant;
                vehicle.Color = dto.Color;
                vehicle.Autonomy = dto.Autonomy;
                vehicle.IdFuelType = dto.IdFuelType;

                _vehicleDomainService?.Update(vehicle);

                var completeVehicle = _vehicleDomainService?.GetById(vehicle.IdVehicle);

                return _mapper.Map<VehicleResponseDto>(completeVehicle);
            }

            catch(VehicleNotFoundException e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public VehicleResponseDto Delete(int id)
        {
            var vehicle = _vehicleDomainService?.GetById(id);
            _vehicleDomainService?.Delete(vehicle);

            return _mapper.Map<VehicleResponseDto>(vehicle);
        }

        public VehicleResponseDto Get(int id)
        {
            var vehicle = _vehicleDomainService?.GetById(id);

            return _mapper.Map<VehicleResponseDto>(vehicle);
        }

        public IEnumerable<VehicleResponseDto> GetAll()
        {
            var vehicles = _vehicleDomainService?.GetAll();
            return _mapper.Map<IEnumerable<VehicleResponseDto>>(vehicles);
        }

        public void Dispose()
        {
            _vehicleDomainService?.Dispose();
        }
    }
}
