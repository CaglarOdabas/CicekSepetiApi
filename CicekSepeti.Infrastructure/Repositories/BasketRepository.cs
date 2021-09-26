using CicekSepeti.Core.Entities;
using CicekSepeti.Core.Repositories;
using CicekSepeti.Infrastructure.Data;
using CicekSepeti.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepeti.Infrastructure.Repositories
{
    public class BasketRepository : Repository<CicekSepeti.Core.Entities.Basket>, IBasketRepository
    {
        public BasketRepository(CicekSepetiContext CicekSepetiContext) : base(CicekSepetiContext)
        {

        }
    }
}
