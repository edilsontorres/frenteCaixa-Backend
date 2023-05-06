using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using projetoCaixa.Entites.Validate.Errors;
using projetoCaixa.Models;
using projetoCaixa.Repositorie.Iterfaces;


namespace projetoCaixa.Controllers
{
    [ApiController]
    [Route("api/cadastro")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<User> _validator;
       
        
        public UserController(IUserRepository userRepository, IValidator<User> validator)
        {
            _userRepository = userRepository;
            _validator = validator;
            
        }
        
        [HttpPost]
        public async Task<ActionResult> NewUser(User user)
        {
            var userValidator = _validator.Validate(user);
            if (!userValidator.IsValid)
            {
                return BadRequest(userValidator.Errors.ToCustomErrorValidator());
            }

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
        }*/


        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveUser(int id)
        {
            var userBanco = await _userRepository.GetUser(id);
            if(userBanco != null)
            {
                _userRepository.RemoveUser(userBanco);
                await _userRepository.SalveAllAsync();
                return Ok("Usuário deletado com sucesso!");
            }
            return BadRequest("Usuário não cadastrado na Base de Dados");
        }
    }
}
