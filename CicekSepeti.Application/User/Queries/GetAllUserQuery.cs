using MediatR;
using System.Collections.Generic;

namespace CicekSepeti.Application.User.Queries
{
    public class GetAllUserQuery : IRequest<List<CicekSepeti.Core.Entities.User>>
    {

    }
}
