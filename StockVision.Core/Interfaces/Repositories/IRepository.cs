﻿namespace StockVision.Core.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> Get(int id);
        Task <IEnumerable<TEntity>> GetAll();
        Task Add(TEntity entity);
        Task AddRange(IEnumerable<TEntity> entities);
    }
}