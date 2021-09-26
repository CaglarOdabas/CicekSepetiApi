using CicekSepeti.Application.Basket.Responses;
using MediatR;

namespace CicekSepeti.Application.Basket.Commands
{
    public class CreateBasketCommand : IRequest<BasketResponse> 
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Piece { get; set; }
    }
}
