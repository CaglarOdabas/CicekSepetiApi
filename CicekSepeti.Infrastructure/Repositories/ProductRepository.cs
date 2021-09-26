using CicekSepeti.Core.Repositories;
using CicekSepeti.Infrastructure.Data;
using CicekSepeti.Infrastructure.Repositories.Base;

namespace CicekSepeti.Infrastructure.Repositories
{
    public class ProductRepository : Repository<CicekSepeti.Core.Entities.Product>, IProductRepository
    {
        public ProductRepository(CicekSepetiContext CicekSepetiContext) : base(CicekSepetiContext)
        {

        }
    }
}
