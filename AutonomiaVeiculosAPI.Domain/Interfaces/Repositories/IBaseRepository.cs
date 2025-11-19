using System;
using System.Collections.Generic;
using System.Linq;
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

        List<TEntity> GetAll();
        List<TEntity> GetAll(Func<TEntity, bool> where);
        TEntity? GetById(Tkey id);
        TEntity? Get(Func<TEntity, bool> where);

    }
}
