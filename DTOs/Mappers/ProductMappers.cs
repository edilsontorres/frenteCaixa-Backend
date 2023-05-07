using AutoMapper;
using projetoCaixa.Entites;

namespace projetoCaixa.DTOs.Mappers
{
    public class ProductMappers : Profile
    {
        public ProductMappers() 
        {
            CreateMap<Product, ProductRequestDTO>().ReverseMap();
            CreateMap<Product, ProductResponseDTO>().ReverseMap();
        }
    }
}
