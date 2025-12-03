using AutonomiaVeiculosAPI.Domain.Interfaces.Messages;
using AutonomiaVeiculosAPI.Infra.Messages.Consumers;
using AutonomiaVeiculosAPI.Infra.Messages.Producers;
using AutonomiaVeiculosAPI.Infra.Messages.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Infra.IoC.Extensions
{
    public static class RabbitMQExtencion
    {
        public static IServiceCollection AddRabbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMQSettings>(configuration.GetSection("RabbitMQSettings"));
            services.AddTransient<IUserMessageProducer, UserMessageProducer>();
            services.AddHostedService<UserMessageConsumer>();

            return services;
        }
    }
}
