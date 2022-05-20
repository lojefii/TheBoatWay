using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext context;
        private DbSet<TEntity> dbSet;
        public GenericRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }
        public void Add(TEntity Entity)
        {
            dbSet.Add(Entity);
            context.SaveChanges();
        }
        public void Delete(int Id)
        {
            dbSet.Remove(dbSet.Find(Id));
            context.SaveChanges();
        }
        public void Delete(TEntity Entity)
        {
            context.Entry(Entity).State = EntityState.Deleted;
            context.SaveChanges();
        }
        public void Clear()
        {
            dbSet.RemoveRange(dbSet);
            context.SaveChanges();
        }
        public void Modify(int Id, TEntity NewItem)
        {
            context.Entry(context.Set<TEntity>().Find(Id)).CurrentValues.SetValues(NewItem);
            context.SaveChanges();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public TEntity Get(int Id)
        {
            return dbSet.Find(Id);
        }
        public TEntity GetByPosition(int Position)
        {
            return dbSet.ToList()[Position];
        }
        public List<TEntity> GetAll()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public List<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = dbSet;
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).ToList();
        }

        public List<TEntity> GetAll(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = dbSet.Where(predicate).AsQueryable();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).ToList();
        }
    }
}