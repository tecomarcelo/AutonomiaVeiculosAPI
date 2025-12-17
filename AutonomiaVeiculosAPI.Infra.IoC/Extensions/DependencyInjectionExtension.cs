using AutonomiaVeiculosAPI.Application.Interfaces;
using AutonomiaVeiculosAPI.Application.Services;
using AutonomiaVeiculosAPI.Domain.Interfaces.Repositories;
using AutonomiaVeiculosAPI.Domain.Interfaces.Services;
using AutonomiaVeiculosAPI.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using AutonomiaVeiculosAPI.Infra.Data.Repositories;
using AutonomiaVeiculosAPI.Infra.Data.Contexts;

namespace AutonomiaVeiculosAPI.Infra.IoC.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IUserAppService, UserAppService>();
            services.AddTransient<IAuthAppService, AuthAppService>();
            services.AddTransient<IFuelingAppService, FuelingAppService>();
            services.AddTransient<IFuelingReportAppService, FuelingReportAppService>();
            services.AddTransient<IFuelTypeAppService, FuelTypeAppService>();
            services.AddTransient<IVehicleAppService, VehicleAppService>();

            services.AddTransient<IUserDomainService, UserDomainService>();
            services.AddTransient<IFuelingDomainService, FuelingDomainService>();
            services.AddTransient<IFuelTypeDomainService, FuelTypeDomainService>();
            services.AddTransient<IVehicleDomainService, VehicleDomainService>();

            services.AddTransient<IFuelingRepository, FuelingRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            
            return services;
        }
    }
}
