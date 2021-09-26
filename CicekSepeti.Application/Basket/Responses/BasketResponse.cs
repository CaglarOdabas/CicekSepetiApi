using CicekSepeti.Application.BaseResponses;

namespace CicekSepeti.Application.Basket.Responses
{
    public class BasketResponse : BaseResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Piece { get; set; }
    }
}
