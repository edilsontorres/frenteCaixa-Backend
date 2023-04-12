using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using projetoCaixa.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace projetoCaixa.Service
{
    public class TokenService
    {

        public TokenService(IConfiguration configuration)
        {
            IConfiguration _configuration;
            _configuration = configuration;
        }
        public static string CreateToken(User user)
        {
            
            IConfiguration _configuration;
            _configuration = 

            var jwtHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Secret").Value!);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName!)
                }
                ),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = jwtHandler.CreateToken(tokenDescription);
            return jwtHandler.WriteToken(token);
        }
    }
}
