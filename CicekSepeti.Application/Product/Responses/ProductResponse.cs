using CicekSepeti.Application.BaseResponses;

namespace CicekSepeti.Application.Product.Responses
{
    public class ProductResponse : BaseResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}
