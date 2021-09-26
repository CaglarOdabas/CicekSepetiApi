using CicekSepeti.Application.BaseResponses;
using CicekSepeti.Application.Product.Commands;
using CicekSepeti.Application.Product.Mapper;
using CicekSepeti.Application.Product.Responses;
using CicekSepeti.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CicekSepeti.Application.Product.Handlers.CommandHandlers
{

    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductResponse>
    {
        private readonly IProductRepository _productRepo;

        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepo = productRepository;
        }
        public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntitiy = ProductMapper.Mapper.Map<CicekSepeti.Core.Entities.Product>(request);
            if (productEntitiy is null)
                return BaseResponse.GetError<ProductResponse>("Issue with mapper");
            var newProduct = await _productRepo.AddAsync(productEntitiy);
            var productResponse = ProductMapper.Mapper.Map<ProductResponse>(newProduct);
            return productResponse;
        }
    }
}
