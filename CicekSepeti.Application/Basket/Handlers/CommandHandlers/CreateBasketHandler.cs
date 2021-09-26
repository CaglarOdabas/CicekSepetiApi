using CicekSepeti.Application.BaseResponses;
using CicekSepeti.Application.Basket.Commands;
using CicekSepeti.Application.Basket.Mapper;
using CicekSepeti.Application.Basket.Responses;
using CicekSepeti.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CicekSepeti.Application.Basket.Handlers.CommandHandlers
{

    public class CreateBasketHandler : IRequestHandler<CreateBasketCommand, BasketResponse>
    {
        private readonly IBasketRepository _basketRepo;
        private readonly IStockRepository _stockRepo;

        public CreateBasketHandler(IBasketRepository basketRepository, IStockRepository stockRepository)
        {
            _basketRepo = basketRepository;
            _stockRepo = stockRepository;
        }
        public async Task<BasketResponse> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
        {
            var basketEntitiy = BasketMapper.Mapper.Map<CicekSepeti.Core.Entities.Basket>(request);
            if (basketEntitiy is null)
                return BaseResponse.GetError<BasketResponse>("Issue with mapper");
            var stockQuery = await _stockRepo.GetBySearchAsync(x => x.ProductId == basketEntitiy.ProductId);
            if (stockQuery.Any())
            {
                var stockCount = stockQuery.Select(x => x.Piece).FirstOrDefault();
                if (stockCount >= basketEntitiy.Piece)
                {
                    var query = (List<Core.Entities.Basket>)await _basketRepo.GetBySearchAsync(x => x.ProductId == basketEntitiy.ProductId && x.UserId == basketEntitiy.UserId);
                    if (query.Any())
                    {
                        var updateBasketEntity = query.FirstOrDefault();
                        updateBasketEntity.Piece = updateBasketEntity.Piece + basketEntitiy.Piece;
                        if (stockCount < updateBasketEntity.Piece)
                            return BaseResponse.GetError<BasketResponse>("insufficient number of products in stock");
                        var updateBasket = await _basketRepo.UpdateAsync(updateBasketEntity);
                        var updatebasketResponse = BasketMapper.Mapper.Map<BasketResponse>(updateBasket);
                        return updatebasketResponse;
                    }
                    var newBasket = await _basketRepo.AddAsync(basketEntitiy);
                    var basketResponse = BasketMapper.Mapper.Map<BasketResponse>(newBasket);
                    return basketResponse;
                }
                return BaseResponse.GetError<BasketResponse>("insufficient number of products in stock");
            }
            return BaseResponse.GetError<BasketResponse>("no products in stock");
        }
    }
}
