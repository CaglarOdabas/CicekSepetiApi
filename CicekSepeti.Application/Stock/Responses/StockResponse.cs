using CicekSepeti.Application.BaseResponses;

namespace CicekSepeti.Application.Stock.Responses
{
    public class StockResponse : BaseResponse
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Piece { get; set; }
    }
}
