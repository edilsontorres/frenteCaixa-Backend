using AutoMapper;
using projetoCaixa.Entites;

namespace projetoCaixa.DTOs.Mappers
{
    public class ProductMappers : Profile
    {
        public ProductMappers() 
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
