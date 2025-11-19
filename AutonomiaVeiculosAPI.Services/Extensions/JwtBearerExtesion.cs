using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace AutonomiaVeiculosAPI.Services.Extensions
{
    public static class JwtBearerExtesion
    {
        public static IServiceCollection AddJwtBearer
            (this IServiceCollection services)
        {
            //politica de autenticação do projeto
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    //definindo preferenciaa para autenticação com token JWT
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true, //validar emissor do token
                        ValidateAudience = true, //validar o destinatário do token
                        ValidateLifetime = true, // validar o tempo de expiraçao do token
                        ValidateIssuerSigningKey = true, //validar a chave secreta utilizada pelo emissor do token
                    };
                });

            return services;
        }
    }
}
