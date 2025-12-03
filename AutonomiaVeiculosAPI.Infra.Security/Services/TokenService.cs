using AutonomiaVeiculosAPI.Domain.Interfaces.Security;
using AutonomiaVeiculosAPI.Domain.ValueObjects;
using AutonomiaVeiculosAPI.Infra.Security.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Infra.Security.Services
{
    public class TokenService : ITokenService
    {
        private readonly TokenSettings? _tokenSettings;

        public TokenService(IOptions<TokenSettings?> tokenSettings)
        {
            _tokenSettings = tokenSettings.Value;
        }

        public string CreateToken(UserAuthVO userAuth)
        {
            //definir as CLAIMS (Identificações para o usuário) que serão gravadas no token;
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, JsonConvert.SerializeObject(userAuth)),
                new Claim(ClaimTypes.Role, userAuth.Role)
            };

            //gerando assinatura antifalsificação do token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings?.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //preenchendo as informações do token
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _tokenSettings?.Issuer,
                audience: _tokenSettings?.Audience,
                claims: claims, //informação de identificação do usuário
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_tokenSettings?.ExperationInMinutes)),
                signingCredentials: credentials //assinatura do token
                );
                
            //retornando o token
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(jwtSecurityToken);
        }
    }
}
