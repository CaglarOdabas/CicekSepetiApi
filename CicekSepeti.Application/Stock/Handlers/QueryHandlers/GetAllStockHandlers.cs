using CicekSepeti.Application.Stock.Queries;
using CicekSepeti.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CicekSepeti.Application.Stock.Handlers.QueryHandlers
{
    public class GetAllStockHandler : IRequestHandler<GetAllStockQuery, List<CicekSepeti.Core.Entities.Stock>>
    {
        private readonly IStockRepository _stockRepo;

        public GetAllStockHandler(IStockRepository stockRepository)
        {
            _stockRepo = stockRepository;
        }
        public async Task<List<Core.Entities.Stock>> Handle(GetAllStockQuery request, CancellationToken cancellationToken)
        {
            return (List<Core.Entities.Stock>)await _stockRepo.GetAllAsync(x => x.Product);
        }
    }
}
