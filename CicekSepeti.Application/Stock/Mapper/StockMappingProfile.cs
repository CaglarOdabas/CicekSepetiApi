using AutoMapper;
using CicekSepeti.Application.Stock.Commands;
using CicekSepeti.Application.Stock.Responses;

namespace CicekSepeti.Application.Stock.Mapper
{
    public class StockMappingProfile : Profile
    {
        public StockMappingProfile()
        {
            CreateMap<CicekSepeti.Core.Entities.Stock, StockResponse>().ReverseMap();
            CreateMap<CicekSepeti.Core.Entities.Stock, CreateStockCommand>().ReverseMap();
        }
    }
}
