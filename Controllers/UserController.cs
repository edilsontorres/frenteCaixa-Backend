using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projetoCaixa.DTOs;
using projetoCaixa.Entites.Validate.Errors;
using projetoCaixa.Models;
using projetoCaixa.Repositorie.Iterfaces;


namespace projetoCaixa.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<UserRequesteDTO> _validator;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IValidator<UserRequesteDTO> validator, IMapper mapper)
        {
            _userRepository = userRepository;
            _validator = validator;
            _mapper = mapper;
            
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetUser()
        {
            var user = await _userRepository.GetUser();
            return (user != null) ? Ok(user) : BadRequest("Ocorreu algum erro com a solicitação!");
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult> GetUserById(int id)
        {
            var userRequest = await _userRepository.GetUserById(id);

            var userResponse = _mapper.Map<UserDetailsResponseDTO>(userRequest);

           return (userResponse != null) 
                ? Ok(userResponse) 
                : NotFound("Usuário não cadastrado!");

        }
        
        [HttpPost("cadastro")]
        [Authorize]
        public async Task<ActionResult<User>> NewUser(UserRequesteDTO user)
        {
            var userValidator = _validator.Validate(user);
            if (!userValidator.IsValid)
            {
                return BadRequest(userValidator.Errors.ToCustomErrorValidator());
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            user.PasswordHash = passwordHash;
            var userRequest = _mapper.Map<User>(user);
            await _userRepository.NewUser(userRequest);

           if(await _userRepository.SalveAllAsync())
           {
               return Ok("Cliente cadastrado com sucesso");
           }
           
           return BadRequest("Algo deu errado!");
        }

        [HttpPut("update/{id}")]
        [Authorize]
        public async Task<ActionResult> UpdateUser(UserRequesteDTO user, int id)
        { 
            var users = await _userRepository.GetUserById(id);
            if (users == null) return BadRequest("Usuário não cadastrado!");  

            var userAtualizar = _mapper.Map(user, users);
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(userAtualizar.PasswordHash);
            users.PasswordHash = passwordHash;
            await _userRepository.UpdateUser(userAtualizar);

            return await _userRepository.SalveAllAsync()
                        ? Ok("Usuário altualizado com sucesso!")
                        : BadRequest("Erro ao atualizar usuário");
        }


        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> RemoveUser(int id)
        {
            var userBanco = await _userRepository.GetUserById(id);
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
