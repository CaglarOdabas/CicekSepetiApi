using MediatR;
using System.Collections.Generic;

namespace CicekSepeti.Application.Product.Queries
{
    public class GetAllProductQuery : IRequest<List<CicekSepeti.Core.Entities.Product>>
    {

    }
}
