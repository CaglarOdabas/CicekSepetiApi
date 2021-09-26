using CicekSepeti.Application.User.Responses;
using MediatR;

namespace CicekSepeti.Application.User.Commands
{
    public class CreateUserCommand : IRequest<UserResponse> 
    {
        public string Username { get; set; }
    }
}
