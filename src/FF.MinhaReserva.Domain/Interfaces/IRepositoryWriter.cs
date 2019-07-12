using FF.MinhaReserva.Domain.Models;
using System;

namespace FF.MinhaReserva.Domain.Interfaces
{
    public interface IRepositoryWriter<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity Add(TEntity opj);
        TEntity Update(TEntity obj);
        void Remove(Guid id);
        int Save();
    }
}
