using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, Tkey> : IDisposable
        where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        
        TEntity? GetById(Tkey id);
        List<TEntity> GetAll();
        
        TEntity? Get(Expression<Func<TEntity, bool>> where);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> where);

    }
}
