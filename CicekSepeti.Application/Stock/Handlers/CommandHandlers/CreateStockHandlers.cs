using CicekSepeti.Application.BaseResponses;
using CicekSepeti.Application.Stock.Commands;
using CicekSepeti.Application.Stock.Mapper;
using CicekSepeti.Application.Stock.Responses;
using CicekSepeti.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CicekSepeti.Application.Stock.Handlers.CommandHandlers
{

    public class CreateStockHandler : IRequestHandler<CreateStockCommand, StockResponse>
    {
        private readonly IStockRepository _stockRepo;

        public CreateStockHandler(IStockRepository stockRepository)
        {
            _stockRepo = stockRepository;
        }
        public async Task<StockResponse> Handle(CreateStockCommand request, CancellationToken cancellationToken)
        {
            var stockEntitiy = StockMapper.Mapper.Map<CicekSepeti.Core.Entities.Stock>(request);
            if (stockEntitiy is null)
                return BaseResponse.GetError<StockResponse>("Issue with mapper");
            var newStock = await _stockRepo.AddAsync(stockEntitiy);
            var stockResponse = StockMapper.Mapper.Map<StockResponse>(newStock);
            return stockResponse;
        }
    }
}
