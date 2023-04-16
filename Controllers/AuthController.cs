using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using projetoCaixa.Models;
using projetoCaixa.Service.Interfaces;
using System.Net.Mail;

namespace projetoCaixa.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly ITokenService _tokenService;

        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> login(User request)
        {
                var tokenService = await _tokenService.CreateToken(user);

                if(user.UserName !=  request.UserName || !BCrypt.Net.BCrypt.Verify(request.PasswordHash, user.PasswordHash))  
                {
                   return BadRequest("Usuário e/ou senha incorretos");

                } else
                {
                    return Ok(tokenService);
                }

        }

    }
}
