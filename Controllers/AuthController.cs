using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using projetoCaixa.Models;
using projetoCaixa.Service;

namespace projetoCaixa.Controllers
{
    
   
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();

        [HttpPost("register")]
        public ActionResult<User> Register(User request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.PasswordHash);

            user.UserName = request.UserName;
            user.PasswordHash = "";
            return Ok(user);
        }

        [HttpPost("login")]
        public ActionResult<User> login(User request)
        {
            var tokenService = TokenService.CreateToken;

            if(user.UserName !=  request.UserName)  
            {
                return BadRequest("Usuário não existe!");
            }

            if(!BCrypt.Net.BCrypt.Verify(request.PasswordHash, user.PasswordHash))
            {
                return BadRequest("Senha errada!");
            }

            string token = tokenService(user);
            Console.WriteLine(token);

            return Ok(token);
        }

    }
}
