using Microsoft.IdentityModel.Tokens;
using projetoCaixa.Models;
using projetoCaixa.Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace projetoCaixa.Service
{
    public class TokenService : ITokenService
    {

        private readonly string secretKey = string.Empty;

        public TokenService(IConfiguration _configuration)
        {
            secretKey = _configuration.GetSection("AppSettings:Secret").Value!;
        }

        public async Task<string> CreateToken(User user)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName!)
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = jwtHandler.CreateToken(tokenDescription);
            return jwtHandler.WriteToken(token);
        }
    }
}
