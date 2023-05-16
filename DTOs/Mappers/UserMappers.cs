using AutoMapper;
using projetoCaixa.Models;

namespace projetoCaixa.DTOs.Mappers
{
    public class UserMappers : Profile
    {
        public UserMappers()
        {
            CreateMap<User, UserRequesteDTO>().ReverseMap();
            CreateMap<User, UserResponseDTO>().ReverseMap();
            CreateMap<User, UserDetailsResponseDTO>().ReverseMap();
        }
    }
}
