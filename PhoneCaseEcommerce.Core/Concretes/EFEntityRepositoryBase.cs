using Microsoft.EntityFrameworkCore;
using PhoneCaseEcommerce.Core.Abstract; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCaseEcommerce.Core.Concretes
{
    public class EFEntityRepositoryBase<TContext, TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext
    {

        private readonly TContext dbContext;

        public EFEntityRepositoryBase(TContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Add(TEntity entity)
        {
            var addedEntity = dbContext.Entry(entity);
            addedEntity.State = EntityState.Added;
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            var deletedEntity = dbContext.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            await dbContext.SaveChangesAsync();
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
          return await dbContext.Set<TEntity>().SingleOrDefaultAsync(filter);
        }

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>>? filter = null)
        {
          return filter==null?
                await dbContext.Set<TEntity>().ToListAsync() :
                await dbContext.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task Update(TEntity entity)
        {
            var updatedEntity = dbContext.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
