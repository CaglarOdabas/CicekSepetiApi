using CicekSepeti.Core.Repositories;
using CicekSepeti.Infrastructure.Data;
using CicekSepeti.Infrastructure.Repositories.Base;

namespace CicekSepeti.Infrastructure.Repositories
{
    public class StockRepository : Repository<CicekSepeti.Core.Entities.Stock>, IStockRepository
    {
        public StockRepository(CicekSepetiContext CicekSepetiContext) : base(CicekSepetiContext)
        {

        }
    }
}
