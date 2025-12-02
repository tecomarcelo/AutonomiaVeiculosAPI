using AutoMapper;
using AutonomiaVeiculosAPI.Application.Dtos.Responses;
using AutonomiaVeiculosAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Application.Mappings
{
    public class ModelToMap : Profile
    {
        public ModelToMap()
        {
            CreateMap<User, UserResponseDto>();
            CreateMap<Vehicle, VehicleResponseDto>();
            CreateMap<Fueling, FuelingResponseDto>();
            CreateMap<FuelType, FuelTypeResponseDto>();
        }
    }
}
