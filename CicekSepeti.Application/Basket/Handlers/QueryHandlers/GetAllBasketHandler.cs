using CicekSepeti.Application.Basket.Queries;
using CicekSepeti.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CicekSepeti.Application.Basket.Handlers.QueryHandlers
{
    public class GetAllBasketHandler : IRequestHandler<GetAllBasketQuery, List<Core.Entities.Basket>>
    {
        private readonly IBasketRepository _basketRepo;

        public GetAllBasketHandler(IBasketRepository basketRepository)
        {
            _basketRepo = basketRepository;
        }
        public async Task<List<Core.Entities.Basket>> Handle(GetAllBasketQuery request, CancellationToken cancellationToken)
        {
            return (List<Core.Entities.Basket>)await _basketRepo.GetAllAsync(x => x.Product, x => x.User);
        }
    }
}
