using CicekSepeti.Core.Repositories.Base;
using CicekSepeti.Infrastructure.Data;
using CicekSepeti.Infrastructure.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CicekSepeti.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly CicekSepetiContext _CicekSepetiContext;

        public Repository(CicekSepetiContext CicekSepetiContext)
        {
            _CicekSepetiContext = CicekSepetiContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _CicekSepetiContext.Set<T>().AddAsync(entity);
            await _CicekSepetiContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _CicekSepetiContext.Set<T>().Remove(entity);
            await _CicekSepetiContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] includeEntities)
        {
            var result = _CicekSepetiContext.Set<T>().AsQueryable();
            if (includeEntities.Length > 0)
                result = result.IncludeMultiple(includeEntities);

            return await result.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _CicekSepetiContext.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _CicekSepetiContext.Entry(entity).State = EntityState.Modified;
            await _CicekSepetiContext.SaveChangesAsync();
            return entity;
        }
        public async Task<IReadOnlyList<T>> GetBySearchAsync(Expression<Func<T, bool>> filter = null)
        {
            return filter == null
                    ? await _CicekSepetiContext.Set<T>().ToListAsync()
                    : await _CicekSepetiContext.Set<T>().Where(filter).ToListAsync();
        }
    }
}
