using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetoCaixa.Data;
using projetoCaixa.Models;
using projetoCaixa.Service.Interfaces;


namespace projetoCaixa.Controllers
{
    
    [ApiController]
    [Route("api/token")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly DataContext _context;

        public AuthController(ITokenService tokenService, DataContext dataContext)
        {
            _tokenService = tokenService;
            _context = dataContext;
           
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login([FromBody] User users)
        {
            var tokenService = await _tokenService.CreateToken(users);
            
            var userRepository = await _context.Users.FirstOrDefaultAsync(x => x.UserName == users.UserName);

            if(userRepository != null)
            {

                if(users.UserName != userRepository.UserName || !BCrypt.Net.BCrypt.Verify(users.PasswordHash, userRepository.PasswordHash))  
                {
                    return BadRequest("Usuário e/ou senha incorretos");
                }
                else
                {
                    return Ok(tokenService);
                }
            }

            return BadRequest("Usuário e/ou senha incorretos");
            
            }

        }
}
