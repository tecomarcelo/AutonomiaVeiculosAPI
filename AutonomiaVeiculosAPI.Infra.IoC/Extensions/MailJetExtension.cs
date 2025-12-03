using AutonomiaVeiculosAPI.Infra.Messages.Services;
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
    public static class MailJetExtension
    {
        public static IServiceCollection AddMailJet(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MailJetSettings>(configuration.GetSection("MailJetSettings"));
            services.AddTransient<EmailMessageService>();

            return services;
        }
    }
}
