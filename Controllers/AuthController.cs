using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetoCaixa.Data;
using projetoCaixa.DTOs;
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
        private readonly IMapper _mapper;

        public AuthController(ITokenService tokenService, DataContext dataContext, IMapper mapper)
        {
            _tokenService = tokenService;
            _context = dataContext;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login([FromBody]UserRequesteDTO user)
        {
            var users = _mapper.Map<User>(user);    
            var tokenService = await _tokenService.CreateToken(users);
            
            var userRepository = await _context.Users.FirstOrDefaultAsync(x => x.UserName == users.UserName);

            if(userRepository != null)
            {
                return (users.UserName != userRepository.UserName || !BCrypt.Net.BCrypt.Verify(users.PasswordHash, userRepository.PasswordHash)) 
                    ? BadRequest("Usuário e / ou senha incorretos") 
                    : Ok(tokenService);
            }

            return BadRequest("Usuário e/ou senha incorretos");
            
        }

    }
}
