using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Application.Stock.Queries
{
    public class GetAllStockQuery : IRequest<List<CicekSepeti.Core.Entities.Stock>>
    {

    }
}
