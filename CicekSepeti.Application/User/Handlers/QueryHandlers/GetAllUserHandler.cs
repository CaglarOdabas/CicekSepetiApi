using CicekSepeti.Application.User.Queries;
using CicekSepeti.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CicekSepeti.Application.User.Handlers.QueryHandlers
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, List<CicekSepeti.Core.Entities.User>>
    {
        private readonly IUserRepository _userRepo;

        public GetAllUserHandler(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }
        public async Task<List<Core.Entities.User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            return (List<Core.Entities.User>)await _userRepo.GetAllAsync();
        }
    }
}
