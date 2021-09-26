using CicekSepeti.Application.Product.Queries;
using CicekSepeti.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CicekSepeti.Application.Product.Handlers.QueryHandlers
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductQuery, List<CicekSepeti.Core.Entities.Product>>
    {
        private readonly IProductRepository _productRepo;

        public GetAllProductHandler(IProductRepository productRepository)
        {
            _productRepo = productRepository;
        }
        public async Task<List<Core.Entities.Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            return (List<Core.Entities.Product>)await _productRepo.GetAllAsync();
        }
    }
}
