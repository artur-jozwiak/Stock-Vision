using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using StockVision.Core.Interfaces.Repositories;
using StockVision.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly StockVisionContext Context;
        public Repository(StockVisionContext context)
        {
            Context = context;
        }

        public virtual async Task<TEntity?> Get(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().Where(predicate).AsNoTracking().ToListAsync();
        }

        public async Task Add(TEntity entity)
        {
           await Context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<TEntity> entities)
        {
           await Context.Set<TEntity>().AddRangeAsync(entities);
        }

        public  void Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }
    }
}
