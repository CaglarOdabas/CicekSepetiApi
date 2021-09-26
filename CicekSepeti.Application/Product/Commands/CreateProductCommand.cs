using CicekSepeti.Application.Product.Responses;
using MediatR;

namespace CicekSepeti.Application.Product.Commands
{
    public class CreateProductCommand : IRequest<ProductResponse>
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}
