using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CicekSepeti.Core.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] includeEntities);
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task <T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IReadOnlyList<T>> GetBySearchAsync(Expression<Func<T, bool>> filter = null);
    }
}
