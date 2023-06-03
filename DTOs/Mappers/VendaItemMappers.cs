using AutoMapper;
using projetoCaixa.Entites;

namespace projetoCaixa.DTOs.Mappers
{
    public class VendaItemMappers : Profile
    {
        public VendaItemMappers()
        {
            CreateMap<ItemVenda, ItemVendaDTO>().ReverseMap();
            CreateMap<ItemVenda, Product>().ReverseMap();
            CreateMap<ItemVendaDTO, Product>().ReverseMap();
        }
    }
}
