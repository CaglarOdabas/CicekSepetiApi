using CicekSepeti.Application.BaseResponses;

namespace CicekSepeti.Application.User.Responses
{
    public class UserResponse : BaseResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
    }
}
