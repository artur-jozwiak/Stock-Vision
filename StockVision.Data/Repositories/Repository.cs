using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using StockVision.Core.Interfaces.Repositories;
using StockVision.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly StockVisionDbContext Context;
        public Repository(StockVisionDbContext context)
        {
            Context = context;
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task Add(TEntity entity)
        {
           await Context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<TEntity> entities)
        {
           await Context.Set<TEntity>().AddRangeAsync(entities);
        }

    }
}
