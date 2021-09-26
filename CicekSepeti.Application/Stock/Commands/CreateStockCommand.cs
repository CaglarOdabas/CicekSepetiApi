using CicekSepeti.Application.Stock.Responses;
using MediatR;

namespace CicekSepeti.Application.Stock.Commands
{
    public class CreateStockCommand : IRequest<StockResponse>
    {
        public int ProductId { get; set; }
        public int Piece { get; set; }
    }
}
