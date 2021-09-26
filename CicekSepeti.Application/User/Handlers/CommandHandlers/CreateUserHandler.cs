using CicekSepeti.Application.BaseResponses;
using CicekSepeti.Application.User.Commands;
using CicekSepeti.Application.User.Mapper;
using CicekSepeti.Application.User.Responses;
using CicekSepeti.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CicekSepeti.Application.User.Handlers.CommandHandlers
{

    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserResponse>
    {
        private readonly IUserRepository _userRepo;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }
        public async Task<UserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userEntitiy = UserMapper.Mapper.Map<CicekSepeti.Core.Entities.User>(request);
            if(userEntitiy is null)
                return BaseResponse.GetError<UserResponse>("Issue with mapper");
            var newUser = await _userRepo.AddAsync(userEntitiy);
            var userResponse = UserMapper.Mapper.Map<UserResponse>(newUser);
            return userResponse;
        }
    }
}
