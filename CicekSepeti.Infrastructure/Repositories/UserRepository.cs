using CicekSepeti.Core.Repositories;
using CicekSepeti.Infrastructure.Data;
using CicekSepeti.Infrastructure.Repositories.Base;

namespace CicekSepeti.Infrastructure.Repositories
{
    public class UserRepository : Repository<CicekSepeti.Core.Entities.User>, IUserRepository
    {
        public UserRepository(CicekSepetiContext CicekSepetiContext) : base(CicekSepetiContext)
        {

        }
    }
}
