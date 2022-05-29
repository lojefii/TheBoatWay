using DAL.Contexts;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext context;
        private readonly DbSet<TEntity> dbSet;
        public GenericRepository(DbContext context)
        {
            this.context = context;
            dbSet = new DatabaseContext().Set<TEntity>();
        }
        public async Task Add(TEntity Entity)
        {
            var Context = context;
            var DbSet = context.Set<TEntity>();
            DbSet.Add(Entity);
            await Context.SaveChangesAsync();
        }
        public async Task Delete(int Id)
        {
            var Context = context;
            var DbSet = context.Set<TEntity>();
            DbSet.Remove(DbSet.Find(Id));
            await Context.SaveChangesAsync().ConfigureAwait(false);

        }
        public async Task Delete(TEntity Entity)
        {
            var Context = context;
            Context.Entry(Entity).State = EntityState.Deleted;
            await Context.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task Clear()
        {
            var Context = context;
            var DbSet = context.Set<TEntity>();
            DbSet.RemoveRange(DbSet);
            await Context.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task Modify(int Id, TEntity NewItem)
        {
            var Context = context;
            Context.Entry(Context.Set<TEntity>().Find(Id)).CurrentValues.SetValues(NewItem);
            await Context.SaveChangesAsync().ConfigureAwait(false);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.SuppressFinalize(this);
        }

        public async Task<TEntity> Get(int Id)
        {
            var DbSet = context.Set<TEntity>();
            return await DbSet.FindAsync(Id).ConfigureAwait(false);
        }
        public async Task<TEntity> GetByPosition(int Position)
        {
            var DbSet = context.Set<TEntity>();
            var result = await DbSet.ToListAsync().ConfigureAwait(false);
            return result[Position];
        }
        public virtual List<TEntity> GetAll()
        {
            var DbSet = context.Set<TEntity>();
            return DbSet.AsNoTracking().ToList();
        }
        public virtual List<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var Context = context;
            var DbSet = context.Set<TEntity>();
            var query = DbSet.AsQueryable();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).ToList();
        }
        public virtual List<TEntity> GetAll(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var Context = context;
            var DbSet = context.Set<TEntity>();
            var query = DbSet.Where(predicate).AsQueryable();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).ToList();
        }
    }
}