using Microsoft.AspNetCore.Mvc;
using projetoCaixa.Models;
using projetoCaixa.Repositorie.Iterfaces;


namespace projetoCaixa.Controllers
{
    [ApiController]
    [Route("api/cadastro")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
       
        
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            
        }
        
        [HttpPost]
        public async Task<ActionResult> NewUser(User user)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            user.PasswordHash = passwordHash;
            await _userRepository.NewUser(user);

           if(await _userRepository.SalveAllAsync())
           {
               return Ok("Cliente cadastrado com sucesso");
           }
           
           return BadRequest("Algo deu errado!");
        }

        /*[HttpPost("update")]
        public ActionResult<User> UpdateUser(User request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.PasswordHash);

            user.UserName = request.UserName;
            user.PasswordHash = passwordHash;
            return Ok(user.UserName);
        }


        [HttpDelete]
        public ActionResult<User> RemoveUser(User request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.PasswordHash);

            user.UserName = request.UserName;
            user.PasswordHash = passwordHash;
            return Ok(user.UserName);
        }*/
    }
}
