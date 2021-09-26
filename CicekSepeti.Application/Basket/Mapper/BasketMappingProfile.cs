using AutoMapper;
using CicekSepeti.Application.Basket.Commands;
using CicekSepeti.Application.Basket.Responses;

namespace CicekSepeti.Application.Basket.Mapper
{
    public class BasketMappingProfile : Profile
    {
        public BasketMappingProfile()
        {
            CreateMap<CicekSepeti.Core.Entities.Basket, BasketResponse>().ReverseMap();
            CreateMap<CicekSepeti.Core.Entities.Basket, CreateBasketCommand>().ReverseMap();
        }
    }
}
