using FF.MinhaReserva.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FF.MinhaReserva.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> ShowAllByPage(int s, int t);
        IEnumerable<TEntity> SearchBy(Expression<Func<TEntity, bool>> predicate);
    }


}
