using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using projetoCaixa.Models;
using projetoCaixa.Service;
using System.Net.Mail;

namespace projetoCaixa.Controllers
{
    
   
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly ITokenService _tokenService;

        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public ActionResult<User> Register(User request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.PasswordHash);

            user.UserName = request.UserName;
            user.PasswordHash = "";
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> login(User request)
        {
            try
            {
                var user =new User();
                user.UserName = "victor";
                user.PasswordHash = "";
                var tokenService = await _tokenService.CreateToken(user);

                //if(user.UserName !=  request.UserName)  
                //{
                //    return BadRequest("Usuário não existe!");
                //}

                //if(!BCrypt.Net.BCrypt.Verify(request.PasswordHash, user.PasswordHash))
                //{
                //    return BadRequest("Senha errada!");
                //}

                //string token = tokenService(user);
                //Console.WriteLine(token);

                return Ok(tokenService);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new {message = ex.Message });
            }
        }

    }
}
