using Gol.Domain.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Gol.Domain.Interface
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        // commands
        void Add(TEntity obj);

        void Update(TEntity obj);

        void  Remove(Guid id);

        // querys
        TEntity GetById(Guid id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetGenericWhere(string conditions);
    }
}