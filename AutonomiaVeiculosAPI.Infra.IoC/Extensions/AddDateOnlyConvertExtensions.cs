using AutonomiaVeiculosAPI.Infra.IoC.Converters;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace AutonomiaVeiculosAPI.Infra.IoC.Extensions
{
    public static class AddDateOnlyConvertExtensions
    {
        public static IServiceCollection AddDateOnlyConvert(this IServiceCollection services)
        {
            services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
            {
                // Conversor personalizado DateOnlyJsonConverter
                options.SerializerOptions.Converters.Add(new DateOnlyJsonConverter());

                // Opcional: Se usar enums e quer eles como strings no JSON
                options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            return services;
        }
    }
}
