using AutonomiaVeiculosAPI.Domain.Interfaces.Repositories;
using AutonomiaVeiculosAPI.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class
    {
        private readonly DataContext? _dataContext;

        protected BaseRepository(DataContext? dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(TEntity entity)
        {
            _dataContext?.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dataContext?.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _dataContext?.Remove(entity);
        }

        public List<TEntity> GetAll()
        {
            return _dataContext?.Set<TEntity>().ToList();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> where)
        {
            return _dataContext?.Set<TEntity>().Where(where).ToList();
        }

        public TEntity? GetById(TKey id)
        {
            return _dataContext?.Set<TEntity>().Find(id);
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> where)
        {
            return _dataContext?.Set<TEntity>().FirstOrDefault(where);
        }

        public void Dispose()
        {
            _dataContext?.Dispose();
        }
    }
}
