using FF.MinhaReserva.Domain.Interfaces;
using FF.MinhaReserva.Domain.Models;
using FF.MinhaReserva.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace FF.MinhaReserva.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepositoryWriter<TEntity>, IRepository<TEntity> where TEntity : Entity, new()
    {
        protected MinhaReservaContext Db;
        protected DbSet<TEntity> DbSet;

        //Because of UoW, the saveChanges method was removed.
        public Repository(MinhaReservaContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity obj)
        {
            var objRet = DbSet.Add(obj);
            //SaveChanges();
            return objRet;
        }

        public virtual TEntity Update(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            Save();
            return obj;
        }

        public virtual void Remove(Guid id)
        {
            var entity = new TEntity { Id = id };
            DbSet.Remove(entity);
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntity> SearchBy(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public int Save()
        {
            return Db.SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> ShowAllByPage(int s, int t)
        {
            return DbSet.Take(t).Skip(s);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

    }
}
