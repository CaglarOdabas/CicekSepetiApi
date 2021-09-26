using MediatR;
using System.Collections.Generic;

namespace CicekSepeti.Application.Basket.Queries
{
    public class GetAllBasketQuery : IRequest<List<Core.Entities.Basket>>
    {

    }
}
