﻿using AutoMapper;
using FluentValidation;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var userRequest = await _userRepository.GetUser(id);
            if(userRequest != null)
            {
                var userResponse = _mapper.Map<UserResponseDTO>(userRequest);
                return Ok(userResponse);
            }

            return NotFound("Usuário não cadastrado!");
        }
        
        [HttpPost("cadastro")]
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
        public async Task<ActionResult> UpdateUser(UserRequesteDTO user, int id)
        { 
            var users = await _userRepository.GetUser(id);
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
