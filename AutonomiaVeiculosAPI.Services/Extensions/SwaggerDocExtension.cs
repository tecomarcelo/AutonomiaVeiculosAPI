using Microsoft.OpenApi.Models;
using System.Reflection;

namespace AutonomiaVeiculosAPI.Services.Extensions
{
    /// <summary>
    /// Classe de configuração do Swagger
    /// </summary>
    public static class SwaggerDocExtension
    {
        public static IServiceCollection AddSwaggerDoc(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API para controle de Abastecimentos",
                    Description = "Projeto desenvolvido em NET9 API - DDD EntityFramework SqlServer",
                    Contact = new OpenApiContact
                    {
                        Name = "Abastecimentos de Veiculos",
                        Url = new Uri("http://www.abastecimentoscars.com.br"),
                        Email = "contato@abastecimentoscars.com.br"
                    }
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });
        
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
        
                        },
                        new List<string>()
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        
                options.IncludeXmlComments(xmlPath);
            });
        
            return services;
        }
        
        public static IApplicationBuilder UseSwaggerDoc(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "UsersAPI");
            });
        
            return app;
        }
    }
}
