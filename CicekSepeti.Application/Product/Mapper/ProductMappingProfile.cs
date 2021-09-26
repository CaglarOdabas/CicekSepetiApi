using AutoMapper;
using CicekSepeti.Application.Product.Commands;
using CicekSepeti.Application.Product.Responses;

namespace CicekSepeti.Application.Product.Mapper
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<CicekSepeti.Core.Entities.Product, ProductResponse>().ReverseMap();
            CreateMap<CicekSepeti.Core.Entities.Product, CreateProductCommand>().ReverseMap();
        }
    }
}
