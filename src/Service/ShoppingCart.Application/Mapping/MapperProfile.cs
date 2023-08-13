using AutoMapper;
using ShoppingCart.Application.Dtos;

namespace ShoppingCart.Application.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Domain.Entities.ShoppingCart, ShoppingCartDto>().ReverseMap();
            CreateMap<Domain.Entities.ShoppingCart, UpdateShoppingCartDto>().ReverseMap();
        }
    }
}
